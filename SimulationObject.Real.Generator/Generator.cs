﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Real.Generator.Panels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.Generator
{
    public class Generator : ISimulationObject, IDoubleValueRead, IObjectValueRead
    {
        private static int                                      mRndCounter;
        private static int                                      RndCounter
        {
            get
            {
                Interlocked.Increment(ref mRndCounter);
                return mRndCounter;
            }
        }

        public                                                  Generator()
        {
            mFSM = new FiniteStateMachine(ESignals.Random.ToString(), () => Random());
            mFSM.addState(ESignals.Sine.ToString(), () => Sine());
            mFSM.addState(ESignals.Square.ToString(), () => Square());
            mFSM.addState(ESignals.Sawtooth.ToString(), () => Sawtooth());
        }

        #region Properties

            private ESignals                                    mSignal     = ESignals.Random;
            public int                                          SignalIndex
            {
                get { return (int)mSignal; }
                set
                {
                    ESignals lNew;
                    try
                    {
                        lNew = (ESignals)value;
                    }
                    catch
                    {
                        throw new ArgumentException("Unknown signal type. ");
                    }
                        

                    if (mSignal != lNew)
                    {
                        mSignal     = lNew;
                        mFSM.State  = lNew.ToString();
                        raisePropertiesChanged();
                    }
                }
            }
            public string                                       SignalString
            {
                get { return mSignal.ToString(); }
                set
                {
                    ESignals lNew;
                    try
                    {
                        lNew = (ESignals)Enum.Parse(typeof(ESignals), value);
                    }
                    catch
                    {
                        throw new ArgumentException("Unknown signal type. ");
                    }

                    if (mSignal != lNew)
                    {
                        mSignal     = lNew;
                        mFSM.State  = lNew.ToString();
                        raisePropertiesChanged();
                    }
                }
            }

            private double                                      mBias       = 0.0D;
            public double                                       Bias
            {
                get { return mBias; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mBias, value)) 
                    {
                        mBias           = value;
                        mBiasPlusAmp    = mBias + mAmplitude;
                        raisePropertiesChanged();
                    }
                }
            }

            private double                                      mAmplitude  = 100.0D;
            public double                                       Amplitude
            {
                get { return mAmplitude; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mAmplitude, value))
                    {
                        mAmplitude      = value;
                        mBiasPlusAmp    = mBias + mAmplitude;
                        raisePropertiesChanged();
                    }
                }
            }

            private uint                                        mPeriodMS   = 1000;
            public uint                                         PeriodMS
            {
                get { return mPeriodMS; }
                set
                {
                    uint lPeriodMS = value;
                    if (lPeriodMS == 0) lPeriodMS = 1;

                    if (mPeriodMS != lPeriodMS)
                    {
                        mPeriodMS = lPeriodMS;
                        raisePropertiesChanged();
                    }
                }
            }

            private uint                                        mTurnMS     = 1;
            public uint                                         TurnMS
            {
                get { return mTurnMS; }
                set
                {
                    uint lTurnMS = value;
                    if (lTurnMS == 0) lTurnMS = 1;

                    if (mTurnMS != lTurnMS)
                    {
                        mTurnMS = lTurnMS;
                        raisePropertiesChanged();
                    }
                }
            }

            private double                                      MaxValue
            {
                get
                {
                    switch(mSignal)
                    {
                        case ESignals.Random:   return mAmplitude + mBias;
                        case ESignals.Sine:     return 2 * mAmplitude + mBias;
                        case ESignals.Square:   return mAmplitude + mBias;
                        case ESignals.Sawtooth: return mAmplitude + mBias;
                    }

                    return 100;
                }
            }

            private double                                      MinValue
            {
                get
                {
                    switch (mSignal)
                    {
                        case ESignals.Random:   return mBias;
                        case ESignals.Sine:     return mBias;
                        case ESignals.Square:   return mBias;
                        case ESignals.Sawtooth: return mBias;
                    }

                    return 0;
                }
            }
        
            private uint                                        mStartMS = 0;
            public uint                                         StartMS
            {
                get { return mStartMS; }
                set
                {
                    uint lStartMS = value;
                    if (lStartMS > mPeriodMS) lStartMS  = mPeriodMS;

                    if (mStartMS != lStartMS)
                    {
                        mStartMS = lStartMS;
                        raisePropertiesChanged();
                    }
                }
            }

        #endregion

        #region IItemUser, IDoubleValueRead, IObjectValueRead

            public int                                          mOnItemHandle       = -1;
            private bool                                        mOnChanged;
            private bool                                        mOn                 = true;
            public bool                                         On
            {
                get { return mOn; }
                set
                {
                    if (mOn != value)
                    {
                        mOn             = value;
                        mOnChanged      = true;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mValueItemHandle    = -1;
            private double                                      mValue;
            public double                                       ValueDouble
            {
                get
                {
                    return mValue;
                }
            }
            public object                                       ValueObject
            {
                get { return ValueDouble; }
            }

            public double[]                                     Thresholds { get { return new double[0]; } }
            public string                                       Units { get { return ""; } }

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    if (mOnItemHandle != -1)
                    {
                        return new int[] {mOnItemHandle};
                    }
                    else
                    {
                        return new int[] {};
                    }
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    if (mOnItemHandle != -1)
                    {
                        return new int[] {mValueItemHandle, mOnItemHandle};
                    }
                    else
                    {
                        return new int[] {mValueItemHandle};
                    }
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                bool lValueChanged  = mValueChanged;
                mValueChanged       = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                lHandles.Add(mValueItemHandle);
                lValues.Add(mValue);

                if (mOnItemHandle != -1)
                {
                    if (!lValueChanged || mOnChanged)
                    {
                        mOnChanged = false;
                        lHandles.Add(mOnItemHandle);
                        lValues.Add(mOn);
                    }
                }

                aItemHandles = lHandles.ToArray();
                aItemValues = lValues.ToArray();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mOnItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for object to switch on. ", lExc);
                    }

                    if (mOn != lValue)
                    {
                        mOn = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Generator", "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Generator":       return new GeneratorPanel(this);
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this, MaxValue, MinValue);
                    case "Bar":             return new DoubleBarPanel(this, MaxValue, MinValue);
                    case "SlidingScale":    return new DoubleSlidingScalePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                ChangedValues?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                ChangedProperties?.Invoke(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                                 setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("On", "");
                lChecker.addItemName(lItem);
                mOnItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                SignalString    = lReader.getAttribute<String>("Signal");
                Bias            = lReader.getAttribute<Double>("Bias", mBias);
                Amplitude       = lReader.getAttribute<Double>("Amplitude", mAmplitude);
                PeriodMS        = lReader.getAttribute<UInt32>("PeriodMS", mPeriodMS);
                TurnMS          = lReader.getAttribute<UInt32>("TurnMS", mTurnMS);
                StartMS         = lReader.getAttribute<UInt32>("StartMS", mStartMS);

                try
                {
                    mValue = (double)mItemBrowser.readItemValue(mValueItemHandle);
                }
                catch
                {
                    if (mSignal > 0)
                    {
                        mPeriodStartMS  = MiscUtils.TimerMS - mStartMS;
                        mCurrentMS      = mStartMS;
                        mFSM.executeStateAction();
                    }   
                }
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {         
                aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Signal", SignalString);
                aXMLTextWriter.WriteAttributeString("Bias", StringUtils.ObjectToString(mBias));
                aXMLTextWriter.WriteAttributeString("Amplitude", StringUtils.ObjectToString(mAmplitude));
                aXMLTextWriter.WriteAttributeString("PeriodMS", StringUtils.ObjectToString(mPeriodMS));
                aXMLTextWriter.WriteAttributeString("TurnMS", StringUtils.ObjectToString(mTurnMS));
                aXMLTextWriter.WriteAttributeString("StartMS", StringUtils.ObjectToString(mStartMS));
            }

            private FiniteStateMachine                          mFSM;
            
            private long                                        mCurrentMS          = 0;
            private long                                        mPeriodStartMS      = 0;
            private bool                                        mNewPeriod          = true;
            private bool                                        mOnLast             = false;

            private Random                                      mRnd                = new Random(RndCounter);
            private double                                      mBiasPlusAmp        = 100.0D;

            private void                                        Random()
            {
                if (mNewPeriod)
                {
                    mValue = mBias + (mAmplitude * mRnd.NextDouble());
                }
            }

            private void                                        Sine()
            {
                mValue = (mBiasPlusAmp + mAmplitude * Math.Sin((double)mCurrentMS * 2.0D * Math.PI / (double)mPeriodMS));
            }

            private void                                        Square()
            {
                if (mCurrentMS >= mTurnMS)
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mValue, mBias))
                    {
                        mValue = mBias;
                    }
                }
                else
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mValue, mBiasPlusAmp))
                    
                    {
                        mValue = mBiasPlusAmp;
                    }
                }
            }

            private void                                        Sawtooth()
            {
                if (mCurrentMS <= mTurnMS)
                {
                    mValue = (mBias + mAmplitude * (double)mCurrentMS / (double)mTurnMS);
                }
                else
                {
                    mValue = (mBiasPlusAmp - mAmplitude * (double)(mCurrentMS - mTurnMS) / (double)(mPeriodMS - mTurnMS));
                }
            }

            public void                                         execute()
            {
                if (mOn)
                {
                    if (mOnLast == false)
                    {
                        mPeriodStartMS  = MiscUtils.TimerMS - mStartMS;
                        mCurrentMS      = mStartMS;
                    }
                    else
                    {
                        mCurrentMS = MiscUtils.TimerMS - mPeriodStartMS;
                    }

                    if (mCurrentMS >= mPeriodMS)
                    {
                        mCurrentMS      = mCurrentMS % mPeriodMS;
                        mPeriodStartMS  = MiscUtils.TimerMS - mCurrentMS;
                        mNewPeriod      = true;
                    }

                    double lLastOutValue = mValue;
                    mFSM.executeStateAction();
                    if (ValuesCompare.NotEqualDelta1.compare(lLastOutValue, mValue) || mOnLast == false)
                    {
                        mValueChanged = true;
                        raiseValuesChanged();
                    }

                    mNewPeriod = false;
                }

                mOnLast = mOn;
            }

            public void                                         beforeActivate()
            {
                mOnLast = false;
            }

            public void                                         afterDeactivate()
            {      
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            public string                                       LastError
            {
                get { return ""; }
            }

            public string[]                                     ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool                                        mDisposed = false;

            public void                                         Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                              Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        if (mFSM != null)
                        {
                            mFSM.Dispose();
                            mFSM = null;
                        }
                    }
                    mDisposed = true;
                }
            }

        #endregion
    }
}
