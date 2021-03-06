﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Animation.ImageMove
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.label_XItem = new System.Windows.Forms.Label();
            this.label_YItem = new System.Windows.Forms.Label();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.panel_Items = new System.Windows.Forms.Panel();
            this.itemEditBox_X = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Y = new Utils.SpecialControls.ItemEditBox();
            this.panel_Image = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.labelControl_HW = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tsButton_Import = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Options = new System.Windows.Forms.ToolStripButton();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Items.SuspendLayout();
            this.panel_Image.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label_XItem
            // 
            this.label_XItem.AutoSize = true;
            this.label_XItem.Location = new System.Drawing.Point(9, 11);
            this.label_XItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_XItem.Name = "label_XItem";
            this.label_XItem.Size = new System.Drawing.Size(21, 17);
            this.label_XItem.TabIndex = 19;
            this.label_XItem.Text = "X:";
            // 
            // label_YItem
            // 
            this.label_YItem.AutoSize = true;
            this.label_YItem.Location = new System.Drawing.Point(254, 11);
            this.label_YItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_YItem.Name = "label_YItem";
            this.label_YItem.Size = new System.Drawing.Size(21, 17);
            this.label_YItem.TabIndex = 21;
            this.label_YItem.Text = "Y:";
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 359);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(498, 46);
            this.panel_OkCancel.TabIndex = 2;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(155, 7);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 0;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // panel_Items
            // 
            this.panel_Items.Controls.Add(this.itemEditBox_X);
            this.panel_Items.Controls.Add(this.label_XItem);
            this.panel_Items.Controls.Add(this.itemEditBox_Y);
            this.panel_Items.Controls.Add(this.label_YItem);
            this.panel_Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Items.Location = new System.Drawing.Point(0, 0);
            this.panel_Items.Name = "panel_Items";
            this.panel_Items.Size = new System.Drawing.Size(498, 38);
            this.panel_Items.TabIndex = 0;
            // 
            // itemEditBox_X
            // 
            this.itemEditBox_X.ItemName = "";
            this.itemEditBox_X.ItemRequirements = "Real, Read, Write, Required";
            this.itemEditBox_X.ItemToolTip = "";
            this.itemEditBox_X.Location = new System.Drawing.Point(36, 4);
            this.itemEditBox_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_X.Name = "itemEditBox_X";
            this.itemEditBox_X.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_X.TabIndex = 0;
            this.itemEditBox_X.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Y
            // 
            this.itemEditBox_Y.ItemName = "";
            this.itemEditBox_Y.ItemRequirements = "Real, Read, Write, Required";
            this.itemEditBox_Y.ItemToolTip = "";
            this.itemEditBox_Y.Location = new System.Drawing.Point(281, 4);
            this.itemEditBox_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Y.Name = "itemEditBox_Y";
            this.itemEditBox_Y.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_Y.TabIndex = 1;
            this.itemEditBox_Y.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // panel_Image
            // 
            this.panel_Image.Controls.Add(this.pictureBox);
            this.panel_Image.Controls.Add(this.toolStrip);
            this.panel_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Image.Location = new System.Drawing.Point(0, 38);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(498, 321);
            this.panel_Image.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Import,
            this.tsButton_Options});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(498, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "Image";
            // 
            // labelControl_HW
            // 
            this.labelControl_HW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl_HW.Appearance.Image = global::SimulationObject.Animation.ImageMove.Properties.Resources.Size;
            this.labelControl_HW.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl_HW.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl_HW.Location = new System.Drawing.Point(6, 334);
            this.labelControl_HW.Name = "labelControl_HW";
            this.labelControl_HW.Size = new System.Drawing.Size(42, 19);
            this.labelControl_HW.TabIndex = 4;
            this.labelControl_HW.Text = "0, 0";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(498, 296);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // tsButton_Import
            // 
            this.tsButton_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Import.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_Import.Image")));
            this.tsButton_Import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Import.Name = "tsButton_Import";
            this.tsButton_Import.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Import.Text = "&Import";
            this.tsButton_Import.Click += new System.EventHandler(this.tsButton_Import_Click);
            // 
            // tsButton_Options
            // 
            this.tsButton_Options.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsButton_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Options.Image = global::SimulationObject.Animation.ImageMove.Properties.Resources.Options;
            this.tsButton_Options.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Options.Name = "tsButton_Options";
            this.tsButton_Options.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Options.Text = "toolStripButton1";
            this.tsButton_Options.Click += new System.EventHandler(this.tsButton_Options_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 405);
            this.ControlBox = false;
            this.Controls.Add(this.labelControl_HW);
            this.Controls.Add(this.panel_Image);
            this.Controls.Add(this.panel_Items);
            this.Controls.Add(this.panel_OkCancel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(516, 452);
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Animation.ImageMove";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Items.ResumeLayout(false);
            this.panel_Items.PerformLayout();
            this.panel_Image.ResumeLayout(false);
            this.panel_Image.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_XItem;
        private System.Windows.Forms.Label label_YItem;
        private Utils.SpecialControls.ItemEditBox itemEditBox_X;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Y;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.Panel panel_Items;
        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Import;
        private System.Windows.Forms.ToolStripButton tsButton_Options;
        private DevExpress.XtraEditors.LabelControl labelControl_HW;
    }
}
