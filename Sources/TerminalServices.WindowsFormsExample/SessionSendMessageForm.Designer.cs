namespace PosInformatique.TerminalServices.WindowsFormsExample
{
    partial class SessionSendMessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.buttons = new System.Windows.Forms.ComboBox();
            this.icon = new System.Windows.Forms.ComboBox();
            this.defaultButtons = new System.Windows.Forms.ComboBox();
            this.title = new System.Windows.Forms.TextBox();
            this.message = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.waitUserSessionAnswer = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 13);
            label1.TabIndex = 1;
            label1.Text = "Buttons :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 42);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 13);
            label2.TabIndex = 1;
            label2.Text = "Icon :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 69);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(80, 13);
            label3.TabIndex = 1;
            label3.Text = "Default button :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 110);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 13);
            label4.TabIndex = 1;
            label4.Text = "Title :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 132);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 13);
            label5.TabIndex = 1;
            label5.Text = "Message :";
            // 
            // buttons
            // 
            this.buttons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buttons.FormattingEnabled = true;
            this.buttons.Location = new System.Drawing.Point(95, 12);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(137, 21);
            this.buttons.TabIndex = 0;
            // 
            // icon
            // 
            this.icon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icon.FormattingEnabled = true;
            this.icon.Location = new System.Drawing.Point(95, 39);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(137, 21);
            this.icon.TabIndex = 0;
            // 
            // defaultButtons
            // 
            this.defaultButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultButtons.FormattingEnabled = true;
            this.defaultButtons.Location = new System.Drawing.Point(95, 66);
            this.defaultButtons.Name = "defaultButtons";
            this.defaultButtons.Size = new System.Drawing.Size(137, 21);
            this.defaultButtons.TabIndex = 0;
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(95, 107);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(339, 20);
            this.title.TabIndex = 2;
            // 
            // message
            // 
            this.message.AcceptsReturn = true;
            this.message.Location = new System.Drawing.Point(12, 149);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message.Size = new System.Drawing.Size(422, 151);
            this.message.TabIndex = 3;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(251, 315);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(120, 315);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 4;
            this.ok.Text = "&OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // waitUserSessionAnswer
            // 
            this.waitUserSessionAnswer.AutoSize = true;
            this.waitUserSessionAnswer.Checked = true;
            this.waitUserSessionAnswer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.waitUserSessionAnswer.Location = new System.Drawing.Point(262, 38);
            this.waitUserSessionAnswer.Name = "waitUserSessionAnswer";
            this.waitUserSessionAnswer.Size = new System.Drawing.Size(156, 17);
            this.waitUserSessionAnswer.TabIndex = 6;
            this.waitUserSessionAnswer.Text = "Wait the answer of the user";
            this.waitUserSessionAnswer.UseVisualStyleBackColor = true;
            // 
            // SessionSendMessageForm
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(446, 350);
            this.Controls.Add(this.waitUserSessionAnswer);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.message);
            this.Controls.Add(this.title);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.defaultButtons);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.buttons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionSendMessageForm";
            this.Text = "Send a message to a session";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox buttons;
        private System.Windows.Forms.ComboBox icon;
        private System.Windows.Forms.ComboBox defaultButtons;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.CheckBox waitUserSessionAnswer;
    }
}