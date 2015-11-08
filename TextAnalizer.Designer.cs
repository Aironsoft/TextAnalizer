namespace TextAnalizer
{
    partial class TextAnalizer
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOpen = new System.Windows.Forms.Button();
            this.lbAdress = new System.Windows.Forms.Label();
            this.rtbWords = new System.Windows.Forms.RichTextBox();
            this.btAnaliza = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbAllChars = new System.Windows.Forms.Label();
            this.lbAllWords = new System.Windows.Forms.Label();
            this.lbUniqueWords = new System.Windows.Forms.Label();
            this.lbWordChars = new System.Windows.Forms.Label();
            this.rtbPopularWords = new System.Windows.Forms.RichTextBox();
            this.rtbOrigins = new System.Windows.Forms.RichTextBox();
            this.lbOrigins = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNeedingfFile = new System.Windows.Forms.Label();
            this.lbAvergWordsLen = new System.Windows.Forms.Label();
            this.lbParagraphs = new System.Windows.Forms.Label();
            this.lbAvergWordsInParagraph = new System.Windows.Forms.Label();
            this.lbAvergCharsInParagraph = new System.Windows.Forms.Label();
            this.panelGraphic = new System.Windows.Forms.Panel();
            this.lbMaxWordsLen = new System.Windows.Forms.Label();
            this.cbGraphicType = new System.Windows.Forms.ComboBox();
            this.cbWords = new System.Windows.Forms.ComboBox();
            this.bgwAllWordsLens = new System.ComponentModel.BackgroundWorker();
            this.bgwUniqWordsLens = new System.ComponentModel.BackgroundWorker();
            this.bgwAllWordsAvergLen = new System.ComponentModel.BackgroundWorker();
            this.bgwUniqWordsAvergLen = new System.ComponentModel.BackgroundWorker();
            this.bgwParagraphLens = new System.ComponentModel.BackgroundWorker();
            this.bgwAvgWordsInParagraph = new System.ComponentModel.BackgroundWorker();
            this.bgwAvgCharsInParagraph = new System.ComponentModel.BackgroundWorker();
            this.bgwWordsPop = new System.ComponentModel.BackgroundWorker();
            this.chbSort = new System.Windows.Forms.CheckBox();
            this.bgwWordsPopSorted = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(5, 12);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(75, 23);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Открыть";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // lbAdress
            // 
            this.lbAdress.AutoSize = true;
            this.lbAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAdress.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAdress.Location = new System.Drawing.Point(84, 12);
            this.lbAdress.Name = "lbAdress";
            this.lbAdress.Size = new System.Drawing.Size(21, 20);
            this.lbAdress.TabIndex = 1;
            this.lbAdress.Text = "...";
            // 
            // rtbWords
            // 
            this.rtbWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbWords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rtbWords.Location = new System.Drawing.Point(5, 68);
            this.rtbWords.Name = "rtbWords";
            this.rtbWords.ReadOnly = true;
            this.rtbWords.Size = new System.Drawing.Size(253, 294);
            this.rtbWords.TabIndex = 2;
            this.rtbWords.Text = "";
            // 
            // btAnaliza
            // 
            this.btAnaliza.Location = new System.Drawing.Point(5, 41);
            this.btAnaliza.Name = "btAnaliza";
            this.btAnaliza.Size = new System.Drawing.Size(75, 23);
            this.btAnaliza.TabIndex = 3;
            this.btAnaliza.Text = "Анализ";
            this.btAnaliza.UseVisualStyleBackColor = true;
            this.btAnaliza.Click += new System.EventHandler(this.btAnaliza_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Текстовые файлы|*.txt|Все|*.*";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(88, 41);
            this.progressBar.Maximum = 500;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(589, 23);
            this.progressBar.TabIndex = 4;
            // 
            // lbAllChars
            // 
            this.lbAllChars.AutoSize = true;
            this.lbAllChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAllChars.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAllChars.Location = new System.Drawing.Point(12, 29);
            this.lbAllChars.Name = "lbAllChars";
            this.lbAllChars.Size = new System.Drawing.Size(20, 17);
            this.lbAllChars.TabIndex = 5;
            this.lbAllChars.Text = "...";
            // 
            // lbAllWords
            // 
            this.lbAllWords.AutoSize = true;
            this.lbAllWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAllWords.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAllWords.Location = new System.Drawing.Point(12, 80);
            this.lbAllWords.Name = "lbAllWords";
            this.lbAllWords.Size = new System.Drawing.Size(20, 17);
            this.lbAllWords.TabIndex = 6;
            this.lbAllWords.Text = "...";
            // 
            // lbUniqueWords
            // 
            this.lbUniqueWords.AutoSize = true;
            this.lbUniqueWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUniqueWords.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbUniqueWords.Location = new System.Drawing.Point(12, 97);
            this.lbUniqueWords.Name = "lbUniqueWords";
            this.lbUniqueWords.Size = new System.Drawing.Size(20, 17);
            this.lbUniqueWords.TabIndex = 7;
            this.lbUniqueWords.Text = "...";
            // 
            // lbWordChars
            // 
            this.lbWordChars.AutoSize = true;
            this.lbWordChars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWordChars.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbWordChars.Location = new System.Drawing.Point(12, 46);
            this.lbWordChars.Name = "lbWordChars";
            this.lbWordChars.Size = new System.Drawing.Size(20, 17);
            this.lbWordChars.TabIndex = 8;
            this.lbWordChars.Text = "...";
            // 
            // rtbPopularWords
            // 
            this.rtbPopularWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbPopularWords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rtbPopularWords.Location = new System.Drawing.Point(268, 68);
            this.rtbPopularWords.Name = "rtbPopularWords";
            this.rtbPopularWords.ReadOnly = true;
            this.rtbPopularWords.Size = new System.Drawing.Size(253, 294);
            this.rtbPopularWords.TabIndex = 9;
            this.rtbPopularWords.Text = "";
            this.rtbPopularWords.SizeChanged += new System.EventHandler(this.rtbPopularWords_SizeChanged);
            // 
            // rtbOrigins
            // 
            this.rtbOrigins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbOrigins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rtbOrigins.Location = new System.Drawing.Point(537, 68);
            this.rtbOrigins.Name = "rtbOrigins";
            this.rtbOrigins.ReadOnly = true;
            this.rtbOrigins.Size = new System.Drawing.Size(140, 294);
            this.rtbOrigins.TabIndex = 10;
            this.rtbOrigins.Text = "";
            // 
            // lbOrigins
            // 
            this.lbOrigins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbOrigins.AutoSize = true;
            this.lbOrigins.BackColor = System.Drawing.Color.Transparent;
            this.lbOrigins.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOrigins.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbOrigins.Location = new System.Drawing.Point(541, 360);
            this.lbOrigins.Name = "lbOrigins";
            this.lbOrigins.Size = new System.Drawing.Size(132, 13);
            this.lbOrigins.TabIndex = 11;
            this.lbOrigins.Text = "Популярность начал слов";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(335, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Слова по популярности";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(74, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Слова по возрастанию";
            // 
            // lbNeedingfFile
            // 
            this.lbNeedingfFile.AutoSize = true;
            this.lbNeedingfFile.BackColor = System.Drawing.Color.Transparent;
            this.lbNeedingfFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNeedingfFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbNeedingfFile.Location = new System.Drawing.Point(4, 0);
            this.lbNeedingfFile.Name = "lbNeedingfFile";
            this.lbNeedingfFile.Size = new System.Drawing.Size(299, 13);
            this.lbNeedingfFile.TabIndex = 14;
            this.lbNeedingfFile.Text = "Файл должен быть в формате \'txt\' и иметь кодировку \'utf-8\'.";
            // 
            // lbAvergWordsLen
            // 
            this.lbAvergWordsLen.AutoSize = true;
            this.lbAvergWordsLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAvergWordsLen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAvergWordsLen.Location = new System.Drawing.Point(12, 131);
            this.lbAvergWordsLen.Name = "lbAvergWordsLen";
            this.lbAvergWordsLen.Size = new System.Drawing.Size(20, 17);
            this.lbAvergWordsLen.TabIndex = 15;
            this.lbAvergWordsLen.Text = "...";
            // 
            // lbParagraphs
            // 
            this.lbParagraphs.AutoSize = true;
            this.lbParagraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbParagraphs.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbParagraphs.Location = new System.Drawing.Point(12, 63);
            this.lbParagraphs.Name = "lbParagraphs";
            this.lbParagraphs.Size = new System.Drawing.Size(20, 17);
            this.lbParagraphs.TabIndex = 16;
            this.lbParagraphs.Text = "...";
            // 
            // lbAvergWordsInParagraph
            // 
            this.lbAvergWordsInParagraph.AutoSize = true;
            this.lbAvergWordsInParagraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAvergWordsInParagraph.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAvergWordsInParagraph.Location = new System.Drawing.Point(12, 148);
            this.lbAvergWordsInParagraph.Name = "lbAvergWordsInParagraph";
            this.lbAvergWordsInParagraph.Size = new System.Drawing.Size(20, 17);
            this.lbAvergWordsInParagraph.TabIndex = 17;
            this.lbAvergWordsInParagraph.Text = "...";
            // 
            // lbAvergCharsInParagraph
            // 
            this.lbAvergCharsInParagraph.AutoSize = true;
            this.lbAvergCharsInParagraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAvergCharsInParagraph.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbAvergCharsInParagraph.Location = new System.Drawing.Point(12, 165);
            this.lbAvergCharsInParagraph.Name = "lbAvergCharsInParagraph";
            this.lbAvergCharsInParagraph.Size = new System.Drawing.Size(20, 17);
            this.lbAvergCharsInParagraph.TabIndex = 18;
            this.lbAvergCharsInParagraph.Text = "...";
            // 
            // panelGraphic
            // 
            this.panelGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraphic.BackColor = System.Drawing.Color.Gray;
            this.panelGraphic.Location = new System.Drawing.Point(3, 185);
            this.panelGraphic.Name = "panelGraphic";
            this.panelGraphic.Size = new System.Drawing.Size(321, 99);
            this.panelGraphic.TabIndex = 19;
            // 
            // lbMaxWordsLen
            // 
            this.lbMaxWordsLen.AutoSize = true;
            this.lbMaxWordsLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMaxWordsLen.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbMaxWordsLen.Location = new System.Drawing.Point(12, 114);
            this.lbMaxWordsLen.Name = "lbMaxWordsLen";
            this.lbMaxWordsLen.Size = new System.Drawing.Size(20, 17);
            this.lbMaxWordsLen.TabIndex = 21;
            this.lbMaxWordsLen.Text = "...";
            // 
            // cbGraphicType
            // 
            this.cbGraphicType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbGraphicType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGraphicType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbGraphicType.FormattingEnabled = true;
            this.cbGraphicType.Items.AddRange(new object[] {
            "Популярность слов",
            "Доля уникальных слов",
            "Длины слов",
            "Средняя длина слов",
            "Длины абзацев",
            "В среднем слов в абзаце",
            "В среднем символов в абзаце"});
            this.cbGraphicType.Location = new System.Drawing.Point(3, 290);
            this.cbGraphicType.Name = "cbGraphicType";
            this.cbGraphicType.Size = new System.Drawing.Size(151, 20);
            this.cbGraphicType.TabIndex = 22;
            this.cbGraphicType.Visible = false;
            this.cbGraphicType.SelectedIndexChanged += new System.EventHandler(this.cbGraphicType_SelectedIndexChanged);
            // 
            // cbWords
            // 
            this.cbWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbWords.FormattingEnabled = true;
            this.cbWords.Items.AddRange(new object[] {
            "Все",
            "Уникальные"});
            this.cbWords.Location = new System.Drawing.Point(160, 290);
            this.cbWords.Name = "cbWords";
            this.cbWords.Size = new System.Drawing.Size(78, 20);
            this.cbWords.TabIndex = 23;
            this.cbWords.Visible = false;
            this.cbWords.SelectedIndexChanged += new System.EventHandler(this.cbWords_SelectedIndexChanged);
            // 
            // bgwAllWordsLens
            // 
            this.bgwAllWordsLens.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAllWordsLens_DoWork);
            // 
            // bgwUniqWordsLens
            // 
            this.bgwUniqWordsLens.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUniqWordsLens_DoWork);
            // 
            // bgwAllWordsAvergLen
            // 
            this.bgwAllWordsAvergLen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAllWordsAvergLen_DoWork);
            // 
            // bgwUniqWordsAvergLen
            // 
            this.bgwUniqWordsAvergLen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUniqWordsAvergLen_DoWork);
            // 
            // bgwParagraphLens
            // 
            this.bgwParagraphLens.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwParagraphLens_DoWork);
            // 
            // bgwAvgWordsInParagraph
            // 
            this.bgwAvgWordsInParagraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAvgWordsInParagraph_DoWork);
            // 
            // bgwAvgCharsInParagraph
            // 
            this.bgwAvgCharsInParagraph.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAvgCharsInParagraph_DoWork);
            // 
            // bgwWordsPop
            // 
            this.bgwWordsPop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWordsPop_DoWork);
            // 
            // chbSort
            // 
            this.chbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbSort.AutoSize = true;
            this.chbSort.BackColor = System.Drawing.Color.Transparent;
            this.chbSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbSort.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chbSort.Location = new System.Drawing.Point(244, 292);
            this.chbSort.Name = "chbSort";
            this.chbSort.Size = new System.Drawing.Size(89, 17);
            this.chbSort.TabIndex = 24;
            this.chbSort.Text = "Сортировать";
            this.chbSort.UseVisualStyleBackColor = false;
            this.chbSort.Visible = false;
            this.chbSort.CheckedChanged += new System.EventHandler(this.chbSort_CheckedChanged);
            // 
            // bgwWordsPopSorted
            // 
            this.bgwWordsPopSorted.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWordsPopSorted_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(679, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(339, 338);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.rtbText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(331, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Текст";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabPage2.Controls.Add(this.panelGraphic);
            this.tabPage2.Controls.Add(this.chbSort);
            this.tabPage2.Controls.Add(this.lbAllChars);
            this.tabPage2.Controls.Add(this.cbWords);
            this.tabPage2.Controls.Add(this.lbAllWords);
            this.tabPage2.Controls.Add(this.cbGraphicType);
            this.tabPage2.Controls.Add(this.lbUniqueWords);
            this.tabPage2.Controls.Add(this.lbMaxWordsLen);
            this.tabPage2.Controls.Add(this.lbWordChars);
            this.tabPage2.Controls.Add(this.lbAvergWordsLen);
            this.tabPage2.Controls.Add(this.lbAvergCharsInParagraph);
            this.tabPage2.Controls.Add(this.lbParagraphs);
            this.tabPage2.Controls.Add(this.lbAvergWordsInParagraph);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(331, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Статистика";
            // 
            // rtbText
            // 
            this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(331, 312);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // TextAnalizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1014, 374);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbNeedingfFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOrigins);
            this.Controls.Add(this.rtbOrigins);
            this.Controls.Add(this.rtbPopularWords);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btAnaliza);
            this.Controls.Add(this.rtbWords);
            this.Controls.Add(this.lbAdress);
            this.Controls.Add(this.btOpen);
            this.MinimumSize = new System.Drawing.Size(700, 255);
            this.Name = "TextAnalizer";
            this.Text = "TextAnalizer";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextAnalizer_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextAnalizer_MouseUp);
            this.Resize += new System.EventHandler(this.TextAnalizer_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Label lbAdress;
        private System.Windows.Forms.RichTextBox rtbWords;
        private System.Windows.Forms.Button btAnaliza;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbAllChars;
        private System.Windows.Forms.Label lbAllWords;
        private System.Windows.Forms.Label lbUniqueWords;
        private System.Windows.Forms.Label lbWordChars;
        private System.Windows.Forms.RichTextBox rtbPopularWords;
        private System.Windows.Forms.RichTextBox rtbOrigins;
        private System.Windows.Forms.Label lbOrigins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNeedingfFile;
        private System.Windows.Forms.Label lbAvergWordsLen;
        private System.Windows.Forms.Label lbParagraphs;
        private System.Windows.Forms.Label lbAvergWordsInParagraph;
        private System.Windows.Forms.Label lbAvergCharsInParagraph;
        private System.Windows.Forms.Panel panelGraphic;
        private System.Windows.Forms.Label lbMaxWordsLen;
        private System.Windows.Forms.ComboBox cbGraphicType;
        private System.Windows.Forms.ComboBox cbWords;
        private System.ComponentModel.BackgroundWorker bgwAllWordsLens;
        private System.ComponentModel.BackgroundWorker bgwUniqWordsLens;
        private System.ComponentModel.BackgroundWorker bgwAllWordsAvergLen;
        private System.ComponentModel.BackgroundWorker bgwUniqWordsAvergLen;
        private System.ComponentModel.BackgroundWorker bgwParagraphLens;
        private System.ComponentModel.BackgroundWorker bgwAvgWordsInParagraph;
        private System.ComponentModel.BackgroundWorker bgwAvgCharsInParagraph;
        private System.ComponentModel.BackgroundWorker bgwWordsPop;
        private System.Windows.Forms.CheckBox chbSort;
        private System.ComponentModel.BackgroundWorker bgwWordsPopSorted;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbText;
    }
}

