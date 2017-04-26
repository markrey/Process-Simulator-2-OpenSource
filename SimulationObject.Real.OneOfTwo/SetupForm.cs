﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.OneOfTwo
{
    public partial class SetupForm : Form
    {
        private OneOfTwo        mOneOfTwo;
        private IItemBrowser    mBrowser;

        public                  SetupForm(OneOfTwo aOneOfTwo, IItemBrowser aBrowser)
        {
            mOneOfTwo   = aOneOfTwo;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mOneOfTwo.mSwitchItemHandle != -1)
            {
                itemEditBox_Switch.ItemName    = mBrowser.getItemNameByHandle(mOneOfTwo.mSwitchItemHandle);
                itemEditBox_Switch.ItemToolTip = mBrowser.getItemToolTipByHandle(mOneOfTwo.mSwitchItemHandle);
            }

            if (mOneOfTwo.mInput1ItemHandle != -1)
            {
                itemEditBox_In1.ItemName    = mBrowser.getItemNameByHandle(mOneOfTwo.mInput1ItemHandle);
                itemEditBox_In1.ItemToolTip = mBrowser.getItemToolTipByHandle(mOneOfTwo.mInput1ItemHandle);
            }

            if (mOneOfTwo.mInput2ItemHandle != -1)
            {
                itemEditBox_In2.ItemName    = mBrowser.getItemNameByHandle(mOneOfTwo.mInput2ItemHandle);
                itemEditBox_In2.ItemToolTip = mBrowser.getItemToolTipByHandle(mOneOfTwo.mInput2ItemHandle);
            }

            if (mOneOfTwo.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mOneOfTwo.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mOneOfTwo.mValueItemHandle);
            }

            spinEdit_In1ToIn2MS.Value = mOneOfTwo.In1ToIn2MS;
            spinEdit_In2ToIn1MS.Value = mOneOfTwo.In2ToIn1MS;
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_Switch.ItemName))
                    {
                        throw new ArgumentException("Switch Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_In1.ItemName))
                    {
                        throw new ArgumentException("Input №1 Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_In2.ItemName))
                    {
                        throw new ArgumentException("Input №2 Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Switch.ItemName);
                    lChecker.addItemName(itemEditBox_In1.ItemName);
                    lChecker.addItemName(itemEditBox_In2.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mOneOfTwo.mSwitchItemHandle = mBrowser.getItemHandleByName(itemEditBox_Switch.ItemName);
                    mOneOfTwo.mInput1ItemHandle = mBrowser.getItemHandleByName(itemEditBox_In1.ItemName);
                    mOneOfTwo.mInput2ItemHandle = mBrowser.getItemHandleByName(itemEditBox_In2.ItemName);
                    mOneOfTwo.mValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);

                    mOneOfTwo.In1ToIn2MS = (uint)spinEdit_In1ToIn2MS.Value;
                    mOneOfTwo.In2ToIn1MS = (uint)spinEdit_In2ToIn1MS.Value;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}