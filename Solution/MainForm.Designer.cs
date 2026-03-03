namespace Solution;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private ComboBox typeBox;
    private ComboBox implBox;

    private TextBox inputBox;
    private TextBox indexBox;
    private TextBox fromBox;
    private TextBox toBox;

    private Button addButton;
    private Button insertButton;
    private Button removeButton;
    private Button removeAtButton;
    private Button clearButton;
    private Button containsButton;
    private Button indexOfButton;
    private Button subListButton;
    private Button sortButton;
    private Button existsButton;
    private Button findButton;
    private Button findAllButton;
    private Button checkAllButton;
    private Button findLastButton;
    private Button findIndexButton;
    private Button findLastIndexButton;
    private Button convertAllButton;
    private Button forEachButton;

    private ListBox listBox;
    private Panel drawPanel;
    private Label countLabel;

    private void InitializeComponent()
    {
        this.Text = "SkipList Demo";
        this.Width = 1000;
        this.Height = 700;

        typeBox = new ComboBox() { Left = 20, Top = 20, Width = 120 };
        typeBox.Items.AddRange(new[] { "int", "string", "MyClass" });
        typeBox.SelectedIndex = 0;
        typeBox.SelectedIndexChanged += (s, e) => CreateNewList();

        implBox = new ComboBox() { Left = 160, Top = 20, Width = 120 };
        implBox.Items.AddRange(new[] { "ArrayList", "LinkedList" });
        implBox.SelectedIndex = 0;
        implBox.SelectedIndexChanged += (s, e) => CreateNewList();

        // Поле для ввода значения элемента.
        // Используется во всех операциях, где требуется само значение:
        // - Add (добавление элемента)
        // - Insert (вставка по индексу)
        // - Remove (удаление по значению)
        // - Contains (проверка наличия)
        // - IndexOf (поиск индекса)
        // - Find / FindLast / Exists (в предикатах)
        // - ConvertAll (как исходное значение)
        //
        // Для типа int и MyClass — ожидается число.
        // Для string — любая строка.
        inputBox = new TextBox() { Left = 300, Top = 20, Width = 100 };


        // Поле для ввода индекса.
        // Используется в операциях, работающих с конкретной позицией:
        // - Insert (вставка по индексу)
        // - RemoveAt (удаление по индексу)
        // - IndexOf (логически связано с индексами)
        //
        // Ожидается целое число.
        indexBox = new TextBox() { Left = 420, Top = 20, Width = 50 };


        // Начальный индекс диапазона.
        // Используется в методе SubList(from, to).
        // Определяет левую границу подсписка.
        //
        // Ожидается целое число.
        fromBox = new TextBox() { Left = 480, Top = 20, Width = 50 };


        // Конечный индекс диапазона.
        // Используется в методе SubList(from, to).
        // Определяет правую границу подсписка.
        //
        // Ожидается целое число.
        // Обычно предполагается, что to >= from.
        toBox = new TextBox() { Left = 540, Top = 20, Width = 50 };

        addButton = new Button() { Text = "Add", Left = 20, Top = 60, Height = 35};
        insertButton = new Button() { Text = "Insert", Left = 100, Top = 60, Height = 35};
        removeButton = new Button() { Text = "Remove", Left = 180, Top = 60, Height = 35, Width = 90};
        removeAtButton = new Button() { Text = "RemoveAt", Left = 280, Top = 60, Height = 35, Width = 110};
        clearButton = new Button() { Text = "Clear", Left = 400, Top = 60, Height = 35};
        containsButton = new Button() { Text = "Contains", Left = 485, Top = 60, Height = 35, Width = 90};
        indexOfButton = new Button() { Text = "IndexOf", Left = 575, Top = 60, Height = 35, Width = 90};
        subListButton = new Button() { Text = "SubList", Left = 670, Top = 60, Height = 35, Width = 90};

        sortButton = new Button() { Text = "Sort", Left = 20, Top = 100, Height = 35};
        existsButton = new Button() { Text = "Exists", Left = 100, Top = 100, Height = 35};
        findButton = new Button() { Text = "Find", Left = 180, Top = 100, Height = 35};
        findAllButton = new Button() { Text = "FindAll", Left = 260, Top = 100, Height = 35, Width = 110};
        checkAllButton = new Button() { Text = "CheckAll", Left = 375, Top = 100, Height = 35, Width = 110};
        findLastButton = new Button() { Text = "FindLast", Left = 490, Top = 100, Height = 35, Width = 110};
        findIndexButton = new Button() { Text = "FindIndex", Left = 605, Top = 100, Height = 35, Width = 110};
        findLastIndexButton = new Button() { Text = "FindLastIndex", Left = 720, Top = 100, Height = 35, Width = 150};
        
        convertAllButton = new Button() { Text = "ConvertAll", Left = 20, Top = 140, Height = 35, Width = 120};
        forEachButton = new Button() { Text = "ForEach", Left = 150, Top = 140, Height = 35, Width = 110};

        listBox = new ListBox()
        {
            Left = 20,
            Top = 180,
            Width = 450,
            Height = 400
        };

        drawPanel = new Panel()
        {
            Left = 500,
            Top = 180,
            Width = 450,
            Height = 400,
            BorderStyle = BorderStyle.FixedSingle
        };

        countLabel = new Label()
        {
            Left = 600,
            Top = 25,
            Width = 150
        };

        addButton.Click += addButton_Click;
        insertButton.Click += insertButton_Click;
        removeButton.Click += removeButton_Click;
        removeAtButton.Click += removeAtButton_Click;
        clearButton.Click += clearButton_Click;
        containsButton.Click += containsButton_Click;
        indexOfButton.Click += indexOfButton_Click;
        subListButton.Click += subListButton_Click;
        sortButton.Click += sortButton_Click;
        existsButton.Click += existsButton_Click;
        findButton.Click += findButton_Click;
        findAllButton.Click += findAllButton_Click;
        checkAllButton.Click += checkAllButton_Click;
        findLastButton.Click += findLastButton_Click;
        findIndexButton.Click += findIndexButton_Click;
        findLastIndexButton.Click += findLastIndexButton_Click;
        convertAllButton.Click += convertAllButton_Click;
        forEachButton.Click += forEachButton_Click;

        Controls.AddRange(new Control[]
        {
            typeBox, implBox, inputBox, indexBox, fromBox, toBox,
            addButton, insertButton, removeButton, removeAtButton,
            clearButton, containsButton, indexOfButton, subListButton,
            sortButton, existsButton, findButton, findAllButton, checkAllButton,
            listBox, drawPanel, countLabel, findLastButton,
            findIndexButton, findLastIndexButton, convertAllButton, forEachButton
        });
    }

    #endregion
}