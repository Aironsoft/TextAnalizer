using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;//для ToList<>()
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//для буфера считывания/записи
using System.Text.RegularExpressions;// для Regex

namespace TextAnalizer
{
    public partial class TextAnalizer : Form
    {
        string bufText = "";

        double graphicMin = 0, graphicMax = 1;

        List<string> AllWords = new List<string>();
        Dictionary<string, int> wordsPops = new Dictionary<string, int>();

        List<string> UniqWords = new List<string>();

        List<string> Paragraphs = new List<string>();
        List<List<string>> ParagraphWords = new List<List<string>>();

        Dictionary<int, double> WordsPop = new Dictionary<int, double>();//популярность слов
        double maxWordsPop = 0;
        bool isAvlbWordsPop = false;

        Dictionary<int, double> WordsPopSorted = new Dictionary<int, double>();//популярность слов по снижению популярности
        double maxWordsPopSorted = 0;
        bool isAvlbWordsPopSorted = false;

        Dictionary<int, double> UniqWordsShare = new Dictionary<int, double>();//для графика долей уникальных слов

        Dictionary<int, double> AllWordsLens = new Dictionary<int, double>();//для графика длин всех слов
        double maxAllWordsLens = 0;
        bool isAvlbAllWordsLens = false;

        Dictionary<int, double> UniqWordsLens = new Dictionary<int, double>();//для графика длин уникальных слов
        double maxUniqWordsLens = 0;
        bool isAvlbUniqWordsLens = false;

        Dictionary<int, double> AllWordsAvergLen = new Dictionary<int, double>();//для графика средней длины слов по всем словам
        double maxAllWordsAvergLen = 0;
        bool isAvlbAllWordsAvergLen = false;

        Dictionary<int, double> UniqWordsAvergLen = new Dictionary<int, double>();//для графика средней длины слов по уникальным словам
        double maxUniqWordsAvergLen = 0;
        bool isAvlbUniqWordsAvergLen = false;

        Dictionary<int, double> ParagraphLen = new Dictionary<int, double>();//для графика длин абзацев
        double maxParagraphLen = 0;
        bool isAvlbParagraphLen = false;

        Dictionary<int, double> AvgWordsInParagraph = new Dictionary<int, double>();//для графика среднего количества слов в абзаце
        double maxAvgWordsInParagraph = 0;
        bool isAvlbAvgWordsInParagraph = false;

        Dictionary<int, double> AvgCharsInParagraph = new Dictionary<int, double>();//для графика среднего количества символов в абзаце
        double maxAvgCharsInParagraph = 0;
        bool isAvlbAvgCharsInParagraph = false;

        int selectedGraphic = 0;

        bool selectGraphicTypeNeedVisible = false;
        bool selectWordsTypeNeedVisible = true;
        bool selectIsSortedNeedVisible = true;

        bool mouseDown = false;

        public TextAnalizer()
        {
            InitializeComponent();

            //cbGraphicType.SelectedIndex = 0;
        }

        /// <summary>
        /// Очищает словари, списки и надписи
        /// </summary>
        private void Clear()
        {
            bufText = "";

            maxAllWordsLens = 0;
            selectedGraphic = 0;

            Graphics gr = panelGraphic.CreateGraphics();
            gr.Clear(panelGraphic.BackColor);
            cbGraphicType.SelectedIndex = 0;
            selectGraphicTypeNeedVisible = false;

            AllWords.Clear();
            wordsPops.Clear();
            UniqWords.Clear();
            Paragraphs.Clear();
            ParagraphWords.Clear();

            WordsPop.Clear();
            WordsPopSorted.Clear();
            UniqWordsShare.Clear();
            AllWordsLens.Clear();
            UniqWordsLens.Clear();
            AllWordsAvergLen.Clear();
            UniqWordsAvergLen.Clear();
            ParagraphLen.Clear();
            AvgWordsInParagraph.Clear();
            AvgCharsInParagraph.Clear();

            rtbWords.Text = "";
            rtbWords.Update();
            rtbPopularWords.Text = "";
            rtbPopularWords.Update();
            rtbOrigins.Text = "";
            rtbOrigins.Update();
            lbAllChars.Text = "...";
            lbAllChars.Update();
            lbWordChars.Text = "...";
            lbWordChars.Update();
            lbParagraphs.Text = "...";
            lbParagraphs.Update();
            lbAllWords.Text = "...";
            lbAllWords.Update();
            lbUniqueWords.Text = "...";
            lbUniqueWords.Update();
            lbMaxWordsLen.Text = "...";
            lbMaxWordsLen.Update();
            lbAvergWordsLen.Text = "...";
            lbAvergWordsLen.Update();
            lbAvergWordsInParagraph.Text = "...";
            lbAvergWordsInParagraph.Update();
            lbAvergCharsInParagraph.Text = "...";
            lbAvergCharsInParagraph.Update();

            progressBar.Value = 0;
        }

        /// <summary>
        /// получение адреса файла, из которого производить чтение текста
        /// </summary>
        private void btOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();//диалоговое окно открытия файла
            string newFileAddress = openFileDialog.FileName;//получение выбранного имени файла

            lbAdress.Text = newFileAddress;
        }

        private void btAnaliza_Click(object sender, EventArgs e)
        {
            Clear();

            FileStream fstr=null;
            if (System.IO.File.Exists(lbAdress.Text))//если файл есть
                fstr = new FileStream(lbAdress.Text, FileMode.Open, FileAccess.ReadWrite);
            else
            {
                lbAdress.Text = "";
                return;
            }

            progressBar.Value = 0;
            double allCharsCount, allWordCharsCount = 0, allWordsCount, uniqWordsCount;

            StreamReader streamRd = new StreamReader(fstr);//,Encoding.UTF32

            bufText = streamRd.ReadToEnd();
            rtbText.Text = bufText;

            Paragraphs = bufText.Split('\n').ToList<string>();

            if (bufText == null || bufText == "")
            {
                MessageBox.Show("Файл пуст");
                return;
            }

            bufText = bufText.ToLower();

            lbAllChars.Text = "Всего символов  -  "+bufText.Length;
            allCharsCount = bufText.Length;
            lbAllChars.Update();


            for(int i=0; i<Paragraphs.Count; i++)
            {
                List<string> prgrWords = new List<string>();
                string paragraph = Paragraphs[i];

                for (int k= paragraph.Length-1; k>=0; k--)
                {
                    char s = paragraph[k];

                    if (s == '.' || s == ',' || s == ';' || s == ':' || s == '?' || s == '!' || s == '"' || s == '‘' || s == '\''
                    || s == '(' || s == ')' || s == '<' || s == '>' || s == '≪' || s == '≫' || s == '«' || s == '»' || s == '”' || s == '…'
                    || s == '–' || s == '—' || s == '*' || s == '“' || s == '„' || s == '%')
                    {
                        paragraph = paragraph.Remove(k, 1);
                    }

                    else if (s == '\n' || s == '\t' || s == '\r')
                    {
                        paragraph = paragraph.Substring(0, k) + " " + paragraph.Substring(k + 1);
                    }

                    //progressBar.Value = (int)(progressBar.Maximum*0.6 * (allCharsCount-i) / allCharsCount);
                }

                prgrWords = paragraph.Split(' ').ToList<string>();

                for (int l = prgrWords.Count - 1; l >= 0; l--)
                {
                    //AllWords[i] = AllWords[i].Trim();
                    if (prgrWords[l] == "")
                        prgrWords.RemoveAt(l);
                    else
                        allWordCharsCount += prgrWords[l].Length;

                    //progressBar.Value = (int)(progressBar.Maximum * 0.6 + progressBar.Maximum * 0.01 * (AllWords.Count - i) / AllWords.Count);
                }

                ParagraphWords.Add(prgrWords);

                AllWords.AddRange(prgrWords);
            }


            lbParagraphs.Text = "Абзацев  -  " + Paragraphs.Count;
            lbParagraphs.Update();

            lbWordChars.Text = "Символов в словах  -  " + allWordCharsCount
                + " ("+Math.Round(100.00* allWordCharsCount / allCharsCount, 2) +"%)";
            lbWordChars.Update();


            allWordsCount = AllWords.Count;
            lbAllWords.Text = "Всего слов  -  " + allWordsCount;
            lbAllWords.Update();

            
            for (int i = 0; i < AllWords.Count; i++)
            {
                string wordToLower = AllWords[i].ToLower();

                if (!UniqWords.Contains(wordToLower))//если такого слова ещё не встречалось
                {
                    UniqWords.Add(wordToLower);
                    wordsPops.Add(wordToLower, 1);

                    if (wordToLower.Length > maxAllWordsLens)
                        maxAllWordsLens = wordToLower.Length;
                }
                else
                {
                    wordsPops[wordToLower]++;
                }

                UniqWordsShare.Add(i, (double)UniqWords.Count / (i+1));//доля уникальных слов при достижении данного слова

                progressBar.Value = (int)(progressBar.Maximum *0.61 + progressBar.Maximum *0.12 * i / AllWords.Count);
            }

            lbUniqueWords.Text = "Уникальных слов  -  " + UniqWords.Count
                + " (" + Math.Round(100.00 * UniqWords.Count / allWordsCount, 2) + "%)";
            uniqWordsCount = UniqWords.Count;
            lbUniqueWords.Update();

            lbMaxWordsLen.Text = "Максимальная длина слова  -  " + maxAllWordsLens;
            lbMaxWordsLen.Update();

            lbAvergWordsLen.Text = "Средняя длина слова  -  " + Math.Round(allWordCharsCount / allWordsCount, 2);
            lbAvergWordsLen.Update();

            lbAvergWordsInParagraph.Text = "В среднем слов в абзаце  -  " + Math.Round(allWordsCount / Paragraphs.Count, 2);
            lbAvergWordsInParagraph.Update();

            lbAvergCharsInParagraph.Text = "В среднем символов в абзаце  -  " + Math.Round(allCharsCount / Paragraphs.Count, 2);
            lbAvergCharsInParagraph.Update();

            UniqWords.Sort();

            Dictionary<string, int> sortedWordsPops = new Dictionary<string, int>();
            sortedWordsPops = wordsPops.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);//сортировка словаря по значениям по убыванию

            selectGraphicTypeNeedVisible = true;
            cbGraphicType.SelectedIndex=0;//выбрать первый график из списка
            cbGraphicType_SelectedIndexChanged(null, EventArgs.Empty);//запустить построение графика по заданному выбору
            //GraphicCreate();//построение графика доли уникальныхуникальных слов


            int uniqWordsNumLen = uniqWordsCount.ToString().Length;

            SortedDictionary<string, int> origins = new SortedDictionary<string, int>();

            //////////
            string outputWords = "";

            rtbWords.Text = "";
            for (int i = 0; i < UniqWords.Count; i++)
            {
                outputWords += UniqWords[i] + "  "+ sortedWordsPops[UniqWords[i]] + "("
                    + Math.Round(100.00 * sortedWordsPops[UniqWords[i]] / uniqWordsCount, uniqWordsNumLen - 1) + "%)\n";

                if (origins.ContainsKey(UniqWords[i].Substring(0, 1)))
                {
                    origins[UniqWords[i].Substring(0, 1)]++;
                }
                else
                    origins.Add(UniqWords[i].Substring(0, 1), 1);

                progressBar.Value = progressBar.Value = (int)(progressBar.Maximum *0.73 + progressBar.Maximum *0.11 * i / UniqWords.Count);
            }

            rtbWords.Text = outputWords;

            /////////////
            string popularWords = "";

            int n = 1;

            rtbPopularWords.Text = "";
            foreach(string s in sortedWordsPops.Keys)
            {
                for(int l=0; l< uniqWordsNumLen- n.ToString().Length; l++)
                {
                    popularWords += "0";
                }
                popularWords += n+". "+s + "  " + sortedWordsPops[s] + "("
                    + Math.Round(100.00 * sortedWordsPops[s] / uniqWordsCount, uniqWordsNumLen - 1) + "%)\n";

                progressBar.Value = (int)(progressBar.Maximum * 0.84 + progressBar.Maximum *0.15 * n / UniqWords.Count);
                n++;
            }

            rtbPopularWords.Text = popularWords;

            ///////////
            string wordOrigins = "";

            int originCountTextLen = origins.Count.ToString().Length;

            n = 1;
            foreach (string s in origins.Keys)
            {
                wordOrigins += s + "  " + origins[s] + "("
                    + Math.Round(100.00 * origins[s] / uniqWordsCount, originCountTextLen) + "%)\n";

                progressBar.Value = (int)(progressBar.Maximum * 0.99 + progressBar.Maximum *0.01 * n / UniqWords.Count);
                n++;
            }

            rtbOrigins.Text = wordOrigins;


            progressBar.Value = progressBar.Maximum;
            progressBar.ForeColor = Color.Blue;

            MessageBox.Show("Анализ закончен!");
        }
        
        
        /// <summary>
         /// Функция построения графика статистики по заданным характеристикам
         /// </summary>
        public void GraphicCreate()
        {
            Graphics gr = panelGraphic.CreateGraphics();
            gr.Clear(panelGraphic.BackColor);

            if (graphicMax == graphicMin)
                graphicMin--;

            Dictionary<int, double> Coords=new Dictionary<int, double>();
            
            switch(selectedGraphic)
            {
                case 11:
                    Coords = new Dictionary<int, double>(WordsPop);//копирует популярность слов по порядку
                    break;
                case 12:
                    Coords = new Dictionary<int, double>(WordsPopSorted);//копирует популярность слов по порядку
                    break;
                case 2:
                    Coords = UniqWordsShare.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 311:
                    Coords = AllWordsLens.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 312:
                    List<double> allWordsLens = AllWordsLens.Values.ToList();
                    allWordsLens = allWordsLens.OrderByDescending(x => x).ToList();
                    for (int i = 0; i < allWordsLens.Count;)
                    {
                        Coords.Add(i, allWordsLens[i++]);
                    }
                    break;
                case 321:
                    Coords = UniqWordsLens.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 322:
                    List<double> uniqWordsLens = UniqWordsLens.Values.ToList();
                    uniqWordsLens = uniqWordsLens.OrderByDescending(x => x).ToList();
                    for (int i = 0; i < uniqWordsLens.Count;)
                    {
                        Coords.Add(i, uniqWordsLens[i++]);
                    }
                    break;
                case 41:
                    Coords=AllWordsAvergLen.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 42:
                    Coords = UniqWordsAvergLen.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 51:
                    Coords = ParagraphLen.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 52:
                    List<double> ParagraphLens = ParagraphLen.Values.ToList();
                    ParagraphLens = ParagraphLens.OrderByDescending(x => x).ToList();
                    for (int i = 0; i < ParagraphLens.Count;)
                    {
                        Coords.Add(i, ParagraphLens[i++]);
                    }
                    break;
                case 6:
                    Coords = AvgWordsInParagraph.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
                case 7:
                    Coords = AvgCharsInParagraph.ToDictionary(coord => coord.Key, coord => coord.Value);
                    break;
            }

            if (Coords.Count > 0)
            {                                                                                                                                                                                    
                Double[] points = new double[panelGraphic.Width];

                for (int i = 0; i < panelGraphic.Width; i++)
                {
                    double approxKey = (Coords.Count - 1) / panelGraphic.Width * i;
                    points[i] = panelGraphic.Height/(graphicMax - graphicMin) * Coords[(int)Math.Round(approxKey)];
                }

                Pen p = new Pen(Color.Blue, 1);// цвет линии графика и ширина
                for (int i = 1; i < panelGraphic.Width; i++)
                {
                    gr.DrawLine(p, i - 1, panelGraphic.Height - (int)points[i - 1], i, panelGraphic.Height - (int)points[i]);// рисуем линию
                }
            }
        }

        private void TextAnalizer_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                mouseDown = true;
            }
        }

        private void TextAnalizer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }


        /// <summary>
        /// Перерисовывает параметры выбора построения графика
        /// </summary>
        private void SelectionGraphicParametersRedraw()
        {
            while (ActiveForm == null) { }

            if (selectGraphicTypeNeedVisible)
            {
                if (TextAnalizer.ActiveForm.Height > 290 && TextAnalizer.ActiveForm.Width>705)
                {
                    cbGraphicType.Visible = true;
                }
                else
                    cbGraphicType.Visible = false;
            }

            if (selectWordsTypeNeedVisible)
            {
                if (TextAnalizer.ActiveForm.Height > 290)
                {
                    cbWords.Visible = true;
                }
                else
                    cbWords.Visible = false;
            }
            else
                cbWords.Visible = false;

            if (selectIsSortedNeedVisible)
            {
                if (TextAnalizer.ActiveForm.Height > 290)
                {
                    chbSort.Visible = true;
                }
                else
                    chbSort.Visible = false;
            }
            else
                chbSort.Visible = false;
            
        }

        private void TextAnalizer_Resize(object sender, EventArgs e)
        {
            if(!mouseDown)//если форма "отпущена"
            {
                Graphics gr = panelGraphic.CreateGraphics();
                gr.Clear(panelGraphic.BackColor);

                GraphicCreate();
            }

            SelectionGraphicParametersRedraw();
        }


        /// <summary>
        /// Изменился график для показа
        /// </summary>
        private void cbGraphicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbGraphicType.SelectedIndex)
            {
                case 0://распределение популярности уникальных слов
                    selectWordsTypeNeedVisible = false;
                    selectIsSortedNeedVisible = true;

                    SelectionGraphicParametersRedraw();

                    chbSort_CheckedChanged(null, EventArgs.Empty);

                    break;
                case 1://доля уникальных слов
                    selectWordsTypeNeedVisible = false;
                    selectIsSortedNeedVisible = false;
                    SelectionGraphicParametersRedraw();

                    selectedGraphic = 2;
                    //if (UniqWordsShare.Count == 0)
                    //{
                    //    bgwGetterGraphicCoords.RunWorkerAsync();
                    //}
                    graphicMin = 0;
                    graphicMax = 1;
                    GraphicCreate();
                    break;
                case 2://длины слов
                    selectWordsTypeNeedVisible = true;
                    selectIsSortedNeedVisible = true;
                    SelectionGraphicParametersRedraw();

                    if (cbWords.SelectedIndex == -1)//если case 1 раньше не случался
                        cbWords.SelectedIndex = 0;
                    else
                        cbWords_SelectedIndexChanged(null, EventArgs.Empty);
                    break;
                case 3://средняя длина слов
                    selectWordsTypeNeedVisible = true;
                    selectIsSortedNeedVisible = false;
                    SelectionGraphicParametersRedraw();

                    if (cbWords.SelectedIndex == -1)//если case 2 раньше не случался
                        cbWords.SelectedIndex = 0;
                    else
                        cbWords_SelectedIndexChanged(null, EventArgs.Empty);
                    break;
                case 4://длины абзацев
                    selectWordsTypeNeedVisible = false;
                    selectIsSortedNeedVisible = true;
                    SelectionGraphicParametersRedraw();

                    chbSort_CheckedChanged(null, EventArgs.Empty);

                    break;
                case 5://в среднем слов в абзаце
                    selectWordsTypeNeedVisible = false;
                    selectIsSortedNeedVisible = false;
                    SelectionGraphicParametersRedraw();

                    selectedGraphic = 6;

                    if (AvgWordsInParagraph.Count == 0)
                    {
                        isAvlbAvgWordsInParagraph = false;
                        bgwAvgWordsInParagraph.RunWorkerAsync();
                    }
                    while (!isAvlbAvgWordsInParagraph) { }

                    graphicMin = 0;
                    graphicMax = maxAvgWordsInParagraph;
                    GraphicCreate();
                    break;
                case 6://в среднем символов в абзаце
                    selectWordsTypeNeedVisible = false;
                    selectIsSortedNeedVisible = false;
                    SelectionGraphicParametersRedraw();

                    selectedGraphic = 7;

                    if (AvgCharsInParagraph.Count == 0)
                    {
                        isAvlbAvgCharsInParagraph = false;
                        bgwAvgCharsInParagraph.RunWorkerAsync();
                    }
                    while (!isAvlbAvgCharsInParagraph) { }

                    graphicMin = 0;
                    graphicMax = maxAvgCharsInParagraph;
                    GraphicCreate();
                    break;
            }
        }

        private void chbSort_CheckedChanged(object sender, EventArgs e)
        {
            if (bufText != "")
            {
                switch (cbGraphicType.SelectedIndex)
                {
                    case 0:
                        if (!chbSort.Checked)
                        {
                            selectedGraphic = 11;

                            if (WordsPop.Count == 0)
                            {
                                isAvlbWordsPop = false;
                                bgwWordsPop.RunWorkerAsync();
                            }

                            while (!isAvlbWordsPop) { }

                            graphicMin = 0;
                            graphicMax = maxWordsPop;
                            GraphicCreate();
                        }
                        else
                        {
                            selectedGraphic = 12;

                            if (WordsPopSorted.Count == 0)
                            {
                                isAvlbWordsPopSorted = false;
                                bgwWordsPopSorted.RunWorkerAsync();
                            }

                            while (!isAvlbWordsPopSorted) { }

                            graphicMin = 0;
                            graphicMax = maxWordsPopSorted;
                            GraphicCreate();
                        }

                        break;

                    case 2:
                        switch (cbWords.SelectedIndex)
                        {
                            case 0:
                                if (!chbSort.Checked)
                                    selectedGraphic = 311;
                                else
                                    selectedGraphic = 312;

                                if (AllWordsLens.Count == 0)
                                {
                                    isAvlbAllWordsLens = false;
                                    bgwAllWordsLens.RunWorkerAsync();
                                }

                                while (!isAvlbAllWordsLens) { }

                                graphicMin = 0;
                                graphicMax = maxAllWordsLens;
                                GraphicCreate();

                                break;

                            case 1:
                                if (!chbSort.Checked)
                                    selectedGraphic = 321;
                                else
                                    selectedGraphic = 322;

                                if (UniqWordsLens.Count == 0)
                                {
                                    isAvlbUniqWordsLens = false;
                                    bgwUniqWordsLens.RunWorkerAsync();
                                }

                                while (!isAvlbUniqWordsLens) { }

                                graphicMin = 0;
                                graphicMax = maxUniqWordsLens;
                                GraphicCreate();

                                break;
                        }
                        break;

                    case 4:
                        if (!chbSort.Checked)
                            selectedGraphic = 51;
                        else
                            selectedGraphic = 52;

                        if (ParagraphLen.Count == 0)
                        {
                            isAvlbParagraphLen = false;
                            bgwParagraphLens.RunWorkerAsync();
                        }
                        while (!isAvlbParagraphLen) { }

                        graphicMin = 0;
                        graphicMax = maxParagraphLen;
                        GraphicCreate();

                        break;
                }
            }
        }

        private void cbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbWords.SelectedIndex)
            {
                case 0:
                    switch (cbGraphicType.SelectedIndex)
                    {
                        case 2:
                            chbSort_CheckedChanged(null, EventArgs.Empty);

                            break;
                        case 3:
                            selectedGraphic = 41;
                            if (AllWordsAvergLen.Count == 0)
                            {
                                isAvlbAllWordsAvergLen = false;
                                bgwAllWordsAvergLen.RunWorkerAsync();
                            }

                            while (!isAvlbAllWordsAvergLen) { }

                            graphicMin = 0;
                            graphicMax = maxAllWordsAvergLen;
                            GraphicCreate();

                            break;
                    }
                    break;
                case 1:
                    switch (cbGraphicType.SelectedIndex)
                    {
                        case 2:
                            chbSort_CheckedChanged(null, EventArgs.Empty);

                            break;
                        case 3:
                            selectedGraphic = 42;
                            if (UniqWordsAvergLen.Count == 0)
                            {
                                isAvlbUniqWordsAvergLen = false;
                                bgwUniqWordsAvergLen.RunWorkerAsync();
                            }

                            while (!isAvlbUniqWordsAvergLen) { }//ожидание окончания изменения UniqWordsAvergLen

                            graphicMin = 0;
                            graphicMax = maxUniqWordsAvergLen;
                            GraphicCreate();

                            break;

                    }
                    break;
            }
        }

        private void bgwWordsPop_DoWork(object sender, DoWorkEventArgs e)
        {
            maxWordsPop = 0;

            if (wordsPops.Count > 0)
            {
                List<int> wPops = new List<int>();

                wPops = wordsPops.Values.ToList<int>();
                maxWordsPop = wPops.Max();

                for (int i = 0; i < wPops.Count;)
                {
                    WordsPop.Add(i, wPops[i++]);
                }

                isAvlbWordsPop = true;
            }
        }

        private void bgwWordsPopSorted_DoWork(object sender, DoWorkEventArgs e)
        {
            maxWordsPopSorted = 0;

            if (wordsPops.Count > 0)
            {
                List<int> wPops = new List<int>();

                wPops = wordsPops.Values.ToList<int>();
                wPops=wPops.OrderByDescending(x => x).ToList();
                maxWordsPopSorted = wPops.Max();

                for (int i = 0; i < wPops.Count;)
                {
                    WordsPopSorted.Add(i, wPops[i++]);
                }
            }

            isAvlbWordsPopSorted = true;
        }

        private void bgwAllWordsLens_DoWork(object sender, DoWorkEventArgs e)
        {
            maxAllWordsLens = 0;

            for (int i = 0; i < AllWords.Count;)
            {
                AllWordsLens.Add(i, AllWords[i].Length);

                if (AllWords[i++].Length > maxAllWordsLens)
                    maxAllWordsLens = AllWords[i - 1].Length;
            }

            isAvlbAllWordsLens = true;
        }

        private void bgwUniqWordsLens_DoWork(object sender, DoWorkEventArgs e)
        {
            maxUniqWordsLens = 0;

            for (int i = 0; i < UniqWords.Count;)
            {
                UniqWordsLens.Add(i, UniqWords[i].Length);

                if (UniqWords[i++].Length > maxUniqWordsLens)
                    maxUniqWordsLens = UniqWords[i - 1].Length;
            }

            isAvlbUniqWordsLens = true;
        }

        private void bgwAllWordsAvergLen_DoWork(object sender, DoWorkEventArgs e)
        {
            maxAllWordsAvergLen = 0;
            double sumAvgLen = 0;
            double AvgLen = 0;

            for (int i = 0; i < AllWords.Count;)
            {
                sumAvgLen += AllWords[i].Length;
                AvgLen = sumAvgLen / (i + 1);
                AllWordsAvergLen.Add(i++, AvgLen);

                if (AvgLen > maxAllWordsAvergLen)
                    maxAllWordsAvergLen = AvgLen;
            }

            isAvlbAllWordsAvergLen = true;
        }

        private void bgwUniqWordsAvergLen_DoWork(object sender, DoWorkEventArgs e)
        {
            maxUniqWordsAvergLen = 0;
            double sumAvgLen = 0;
            double AvgLen = 0;

            for (int i = 0; i < UniqWords.Count;)
            {
                sumAvgLen += UniqWords[i].Length;
                AvgLen = sumAvgLen / (i + 1);
                UniqWordsAvergLen.Add(i++, AvgLen);

                if (AvgLen > maxUniqWordsAvergLen)
                    maxUniqWordsAvergLen = AvgLen;
            }

            isAvlbUniqWordsAvergLen = true;
        }

        private void bgwParagraphLens_DoWork(object sender, DoWorkEventArgs e)
        {
            maxParagraphLen = 0;
            int paragraphLen = 0;
            int paragraphNumber = 0;

            for (int i = 0; i < Paragraphs.Count; i++)
            {
                paragraphLen = Paragraphs[i].Length;
                ParagraphLen.Add(paragraphNumber++, paragraphLen);

                if (paragraphLen > maxParagraphLen)
                    maxParagraphLen = paragraphLen;
            }

            isAvlbParagraphLen = true;
        }

        private void bgwAvgWordsInParagraph_DoWork(object sender, DoWorkEventArgs e)//в среднем слов в абзаце
        {
            maxAvgWordsInParagraph = 0;
            double wordsInParagraph = 0;
            double avgWordsInParagraph = 0;
            int paragraphNumber = 0;

            for (int i = 0; i < ParagraphWords.Count; i++)
            {
                wordsInParagraph += ParagraphWords[i].Count;
                avgWordsInParagraph = wordsInParagraph / ++paragraphNumber;
                AvgWordsInParagraph.Add(paragraphNumber - 1, avgWordsInParagraph);

                if (avgWordsInParagraph > maxAvgWordsInParagraph)
                    maxAvgWordsInParagraph = avgWordsInParagraph;
            }

            isAvlbAvgWordsInParagraph = true;
        }

        private void rtbPopularWords_SizeChanged(object sender, EventArgs e)
        {
            rtbPopularWords.Update();
        }

        private void bgwAvgCharsInParagraph_DoWork(object sender, DoWorkEventArgs e)//в среднем символов в абзаце
        {
            maxAvgCharsInParagraph = 0;
            double charsInParagraph = 0;
            double avgCharsInParagraph = 0;
            int paragraphNumber = 0;

            for (int i = 0; i < Paragraphs.Count; i++)
            {
                charsInParagraph += Paragraphs[i].Length;
                avgCharsInParagraph = charsInParagraph / ++paragraphNumber;
                AvgCharsInParagraph.Add(paragraphNumber - 1, charsInParagraph / paragraphNumber);

                if (avgCharsInParagraph > maxAvgCharsInParagraph)
                    maxAvgCharsInParagraph = avgCharsInParagraph;
            }
            //chbSort.Visible = false;

            isAvlbAvgCharsInParagraph = true;
        }

    }
}