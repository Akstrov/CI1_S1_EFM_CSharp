namespace efm_c_
{
    partial class ClubsManagement
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            materialLabel1 = new MaterialSkin2DotNet.Controls.MaterialLabel();
            txtNom = new MaterialSkin2DotNet.Controls.MaterialTextBox2();
            txtId = new MaterialSkin2DotNet.Controls.MaterialTextBox2();
            btnAdd = new MaterialSkin2DotNet.Controls.MaterialButton();
            btnUpdate = new MaterialSkin2DotNet.Controls.MaterialButton();
            btnFetchMembers = new MaterialSkin2DotNet.Controls.MaterialButton();
            btnFetshEvents = new MaterialSkin2DotNet.Controls.MaterialButton();
            dgvClubs = new MaterialSkin2DotNet.Controls.MaterialDataTable();
            ((System.ComponentModel.ISupportInitialize)dgvClubs).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin2DotNet.MaterialSkinManager.fontType.H4;
            materialLabel1.Location = new Point(269, 79);
            materialLabel1.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(252, 41);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Gestion de clubs";
            // 
            // txtNom
            // 
            txtNom.AnimateReadOnly = false;
            txtNom.AutoCompleteMode = AutoCompleteMode.None;
            txtNom.AutoCompleteSource = AutoCompleteSource.None;
            txtNom.BackgroundImageLayout = ImageLayout.None;
            txtNom.CharacterCasing = CharacterCasing.Normal;
            txtNom.Depth = 0;
            txtNom.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNom.HideSelection = true;
            txtNom.Hint = "Nom";
            txtNom.LeadingIcon = null;
            txtNom.Location = new Point(121, 144);
            txtNom.MaxLength = 32767;
            txtNom.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            txtNom.Name = "txtNom";
            txtNom.PasswordChar = '\0';
            txtNom.PrefixSuffixText = null;
            txtNom.ReadOnly = false;
            txtNom.RightToLeft = RightToLeft.No;
            txtNom.SelectedText = "";
            txtNom.SelectionLength = 0;
            txtNom.SelectionStart = 0;
            txtNom.ShortcutsEnabled = true;
            txtNom.Size = new Size(400, 48);
            txtNom.TabIndex = 1;
            txtNom.TabStop = false;
            txtNom.TextAlign = HorizontalAlignment.Left;
            txtNom.TrailingIcon = null;
            txtNom.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.AutoCompleteMode = AutoCompleteMode.None;
            txtId.AutoCompleteSource = AutoCompleteSource.None;
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Enabled = false;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(121, 205);
            txtId.MaxLength = 32767;
            txtId.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = false;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(400, 48);
            txtId.TabIndex = 2;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = false;
            btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdd.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAdd.Depth = 0;
            btnAdd.HighEmphasis = true;
            btnAdd.Icon = null;
            btnAdd.Location = new Point(544, 150);
            btnAdd.Margin = new Padding(4, 6, 4, 6);
            btnAdd.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            btnAdd.Name = "btnAdd";
            btnAdd.NoAccentTextColor = Color.Empty;
            btnAdd.Size = new Size(147, 36);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Ajouter";
            btnAdd.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAdd.UseAccentColor = false;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = false;
            btnUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdate.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUpdate.Depth = 0;
            btnUpdate.HighEmphasis = true;
            btnUpdate.Icon = null;
            btnUpdate.Location = new Point(544, 211);
            btnUpdate.Margin = new Padding(4, 6, 4, 6);
            btnUpdate.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.NoAccentTextColor = Color.Empty;
            btnUpdate.Size = new Size(147, 36);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Modifier";
            btnUpdate.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUpdate.UseAccentColor = false;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnFetchMembers
            // 
            btnFetchMembers.AutoSize = false;
            btnFetchMembers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFetchMembers.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFetchMembers.Depth = 0;
            btnFetchMembers.HighEmphasis = true;
            btnFetchMembers.Icon = null;
            btnFetchMembers.Location = new Point(141, 267);
            btnFetchMembers.Margin = new Padding(4, 6, 4, 6);
            btnFetchMembers.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            btnFetchMembers.Name = "btnFetchMembers";
            btnFetchMembers.NoAccentTextColor = Color.Empty;
            btnFetchMembers.Size = new Size(213, 36);
            btnFetchMembers.TabIndex = 5;
            btnFetchMembers.Text = "Afficher les membres";
            btnFetchMembers.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFetchMembers.UseAccentColor = false;
            btnFetchMembers.UseVisualStyleBackColor = true;
            btnFetchMembers.Click += btnFetchMembers_Click;
            // 
            // btnFetshEvents
            // 
            btnFetshEvents.AutoSize = false;
            btnFetshEvents.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFetshEvents.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFetshEvents.Depth = 0;
            btnFetshEvents.HighEmphasis = true;
            btnFetshEvents.Icon = null;
            btnFetshEvents.Location = new Point(443, 267);
            btnFetshEvents.Margin = new Padding(4, 6, 4, 6);
            btnFetshEvents.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            btnFetshEvents.Name = "btnFetshEvents";
            btnFetshEvents.NoAccentTextColor = Color.Empty;
            btnFetshEvents.Size = new Size(213, 36);
            btnFetshEvents.TabIndex = 6;
            btnFetshEvents.Text = "Afficher les evennements";
            btnFetshEvents.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFetshEvents.UseAccentColor = false;
            btnFetshEvents.UseVisualStyleBackColor = true;
            // 
            // dgvClubs
            // 
            dgvClubs.AllowUserToDeleteRows = false;
            dgvClubs.AllowUserToResizeRows = false;
            dgvClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClubs.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvClubs.BorderStyle = BorderStyle.None;
            dgvClubs.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            dgvClubs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClubs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClubs.ColumnHeadersHeight = 56;
            dgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 137, 123);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvClubs.DefaultCellStyle = dataGridViewCellStyle2;
            dgvClubs.Depth = 0;
            dgvClubs.EnableHeadersVisualStyles = false;
            dgvClubs.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvClubs.GridColor = Color.FromArgb(239, 239, 239);
            dgvClubs.Location = new Point(6, 337);
            dgvClubs.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            dgvClubs.Name = "dgvClubs";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvClubs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvClubs.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dgvClubs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvClubs.RowTemplate.Height = 52;
            dgvClubs.ScrollBars = ScrollBars.None;
            dgvClubs.ShowVerticalScroll = false;
            dgvClubs.Size = new Size(800, 240);
            dgvClubs.TabIndex = 7;
            dgvClubs.Click += dgvClubs_Click;
            // 
            // ClubsManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 583);
            Controls.Add(dgvClubs);
            Controls.Add(btnFetshEvents);
            Controls.Add(btnFetchMembers);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtId);
            Controls.Add(txtNom);
            Controls.Add(materialLabel1);
            Name = "ClubsManagement";
            PrimaryColor = MaterialSkin2DotNet.Primary.Teal600;
            PrimaryDarkColor = MaterialSkin2DotNet.Primary.Teal900;
            PrimaryLightColor = MaterialSkin2DotNet.Primary.Teal100;
            Text = "Clubs";
            Click += ClubsManagement_Click;
            ((System.ComponentModel.ISupportInitialize)dgvClubs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin2DotNet.Controls.MaterialLabel materialLabel1;
        private MaterialSkin2DotNet.Controls.MaterialTextBox2 txtNom;
        private MaterialSkin2DotNet.Controls.MaterialTextBox2 txtId;
        private MaterialSkin2DotNet.Controls.MaterialButton btnAdd;
        private MaterialSkin2DotNet.Controls.MaterialButton btnUpdate;
        private MaterialSkin2DotNet.Controls.MaterialButton btnFetchMembers;
        private MaterialSkin2DotNet.Controls.MaterialButton btnFetshEvents;
        private MaterialSkin2DotNet.Controls.MaterialDataTable dgvClubs;
    }
}