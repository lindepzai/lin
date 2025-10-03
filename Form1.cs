    using System;
    using System.Drawing;
    using System.Windows.Forms;

    namespace ATMInterfaceWinForms
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.KeyPreview = true;
                this.KeyDown += Form1_KeyDown;
            }

            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }

            // Hàm tạo bảng chứa nút (đều hàng)
            private TableLayoutPanel CreateButtonTable(string[] buttonTexts)
            {
                TableLayoutPanel panel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = buttonTexts.Length,
                    BackColor = Color.Transparent,
                    Padding = new Padding(20)
                };

                for (int i = 0; i < buttonTexts.Length; i++)
                {
                    panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F)); // chia đều 4 nút
                    Button btn = new Button
                    {
                        Text = buttonTexts[i],
                        Dock = DockStyle.Fill, // luôn chiếm hết ô
                        Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                        BackColor = Color.FromArgb(227, 242, 253),
                        ForeColor = Color.FromArgb(25, 118, 210),
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Margin = new Padding(10)
                    };

                    btn.FlatAppearance.BorderSize = 2;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(187, 222, 251);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(187, 222, 251);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(144, 202, 249);

                    btn.Click += Button_Click;
                    panel.Controls.Add(btn, 0, i);
                }

                return panel;
            }

            // Xử lý click cho tất cả nút
            private void Button_Click(object sender, EventArgs e)
            {
                if (sender is Button btn)
                {
                    MessageBox.Show($"👉 Bạn đã chọn: {btn.Text}",
                        "ATM Interface",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);

                this.Text = "Giao Diện ATM - UTEBANK";
                this.WindowState = FormWindowState.Maximized;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.FromArgb(245, 245, 245);
                this.FormBorderStyle = FormBorderStyle.None;

                TableLayoutPanel mainPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    RowCount = 3,
                    Padding = new Padding(40)
                };

                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Header
                Panel headerPanel = new Panel
                {
                    Height = 250,
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                PictureBox logoBox = new PictureBox
                {
                    Size = new Size(300, 160),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    Dock = DockStyle.Top,
                    Image = ATM.Properties.Resources.UTEBankLogo
                };

                Label titleLabel = new Label
                {
                    Text = "Xin vui lòng lựa chọn giao dịch",
                    Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(25, 118, 210),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Bottom,
                    Height = 100
                };

                headerPanel.Controls.Add(titleLabel);
                headerPanel.Controls.Add(logoBox);
                mainPanel.Controls.Add(headerPanel, 0, 0);
                mainPanel.SetColumnSpan(headerPanel, 3);

                // Bên trái
                Panel leftPanel = CreateButtonTable(new string[]
                {
                    "📊 Xem số dư",
                    "💵 Rút tiền",
                   "💸 Chuyển tiền",
                
               
                });
                mainPanel.Controls.Add(leftPanel, 0, 1);

                // Bên phải
                Panel rightPanel = CreateButtonTable(new string[]
                {

                    "🔑 Đổi PIN",
                    "📱 Thoát và trả thẻ ",
                
                });
                mainPanel.Controls.Add(rightPanel, 2, 1);

                // Footer
                Label footerLabel = new Label
                {
                    Text = "© 2025 UTEBANK - An toàn & Tiện lợi",
                    Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                    ForeColor = Color.DimGray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 20, 0, 20)
                };
                mainPanel.Controls.Add(footerLabel, 0, 2);
                mainPanel.SetColumnSpan(footerLabel, 3);

                this.Controls.Add(mainPanel);
            }

            private void Form1_Load(object sender, EventArgs e) { }
        }
    }
