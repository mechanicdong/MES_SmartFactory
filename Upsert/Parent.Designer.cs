using MetroFramework.Forms;
using System.Windows.Forms;

namespace Upsert
{
    partial class Parent
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                foreach (Form OpenForm in this.MdiChildren)
                {
                    OpenForm.WindowState = FormWindowState.Normal;
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.defectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defectDTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.workerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEPTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.lbl_MessageText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1880, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workCenterToolStripMenuItem,
            this.productMasterToolStripMenuItem,
            this.toolStripSeparator1,
            this.defectToolStripMenuItem,
            this.defectDTLToolStripMenuItem,
            this.toolStripSeparator2,
            this.workerToolStripMenuItem,
            this.dEPTToolStripMenuItem,
            this.inspectorToolStripMenuItem,
            this.teamToolStripMenuItem,
            this.plantToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.formToolStripMenuItem.Text = "기준정보";
            // 
            // workCenterToolStripMenuItem
            // 
            this.workCenterToolStripMenuItem.Name = "workCenterToolStripMenuItem";
            this.workCenterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.workCenterToolStripMenuItem.Text = "작업센터";
            this.workCenterToolStripMenuItem.Click += new System.EventHandler(this.workCenterToolStripMenuItem_Click);
            // 
            // productMasterToolStripMenuItem
            // 
            this.productMasterToolStripMenuItem.Name = "productMasterToolStripMenuItem";
            this.productMasterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productMasterToolStripMenuItem.Text = "제품정보";
            this.productMasterToolStripMenuItem.Click += new System.EventHandler(this.productMasterToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // defectToolStripMenuItem
            // 
            this.defectToolStripMenuItem.Name = "defectToolStripMenuItem";
            this.defectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defectToolStripMenuItem.Text = "불량";
            this.defectToolStripMenuItem.Click += new System.EventHandler(this.defectToolStripMenuItem_Click);
            // 
            // defectDTLToolStripMenuItem
            // 
            this.defectDTLToolStripMenuItem.Name = "defectDTLToolStripMenuItem";
            this.defectDTLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defectDTLToolStripMenuItem.Text = "불량상세";
            this.defectDTLToolStripMenuItem.Click += new System.EventHandler(this.defectDTLToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // workerToolStripMenuItem
            // 
            this.workerToolStripMenuItem.Name = "workerToolStripMenuItem";
            this.workerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.workerToolStripMenuItem.Text = "근무조";
            this.workerToolStripMenuItem.Click += new System.EventHandler(this.workerToolStripMenuItem_Click);
            // 
            // dEPTToolStripMenuItem
            // 
            this.dEPTToolStripMenuItem.Name = "dEPTToolStripMenuItem";
            this.dEPTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dEPTToolStripMenuItem.Text = "부서";
            this.dEPTToolStripMenuItem.Click += new System.EventHandler(this.dEPTToolStripMenuItem_Click);
            // 
            // inspectorToolStripMenuItem
            // 
            this.inspectorToolStripMenuItem.Name = "inspectorToolStripMenuItem";
            this.inspectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inspectorToolStripMenuItem.Text = "검사원";
            this.inspectorToolStripMenuItem.Click += new System.EventHandler(this.inspectorToolStripMenuItem_Click);
            // 
            // teamToolStripMenuItem
            // 
            this.teamToolStripMenuItem.Name = "teamToolStripMenuItem";
            this.teamToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.teamToolStripMenuItem.Text = "팀";
            this.teamToolStripMenuItem.Click += new System.EventHandler(this.teamToolStripMenuItem_Click);
            // 
            // plantToolStripMenuItem
            // 
            this.plantToolStripMenuItem.Name = "plantToolStripMenuItem";
            this.plantToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.plantToolStripMenuItem.Text = "공장";
            this.plantToolStripMenuItem.Click += new System.EventHandler(this.plantToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btn_Select, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 84);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1880, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.Transparent;
            this.btn_Select.BackgroundImage = global::Upsert.Properties.Resources.조회;
            this.btn_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.Location = new System.Drawing.Point(0, 0);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(100, 100);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            this.btn_Select.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Select_MouseDown);
            this.btn_Select.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Select_MouseUp);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackgroundImage = global::Upsert.Properties.Resources.삭제;
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Location = new System.Drawing.Point(200, 0);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(100, 100);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            this.btn_Delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Delete_MouseDown);
            this.btn_Delete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Delete_MouseUp);
            // 
            // btn_Save
            // 
            this.btn_Save.BackgroundImage = global::Upsert.Properties.Resources.저장;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(100, 0);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 100);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            this.btn_Save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Save_MouseDown);
            this.btn_Save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Save_MouseUp);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_Message, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_MessageText, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 960);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1880, 100);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Message.Font = new System.Drawing.Font("굴림", 20F);
            this.lbl_Message.Location = new System.Drawing.Point(3, 0);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(182, 100);
            this.lbl_Message.TabIndex = 0;
            this.lbl_Message.Text = "Message :";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_MessageText
            // 
            this.lbl_MessageText.AutoSize = true;
            this.lbl_MessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MessageText.Font = new System.Drawing.Font("굴림", 20F);
            this.lbl_MessageText.Location = new System.Drawing.Point(191, 0);
            this.lbl_MessageText.Name = "lbl_MessageText";
            this.lbl_MessageText.Size = new System.Drawing.Size(1686, 100);
            this.lbl_MessageText.TabIndex = 1;
            this.lbl_MessageText.Text = "작업 내용이 없습니다.";
            this.lbl_MessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Parent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Parent";
            this.Text = "기준정보";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.Parent_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label lbl_MessageText;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem workerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inspectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEPTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defectDTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

