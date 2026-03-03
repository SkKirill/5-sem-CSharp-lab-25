using Solution.Lists;
using Solution.Models;

namespace Solution;

public partial class MainForm : Form
{
    private Lists.IList<int> intList;
    private Lists.IList<string> stringList;
    private Lists.IList<MyClass> myClassList;

    public MainForm()
    {
        InitializeComponent();
        InitLists();
    }

    private void InitLists()
    {
        CreateNewList();
    }

    private void CreateNewList()
    {
        try
        {
            string type = typeBox.SelectedItem.ToString();
            string impl = implBox.SelectedItem.ToString();

            if (type == "int")
                intList = impl == "ArrayList"
                    ? new ArrayList<int>()
                    : new Lists.LinkedList<int>();

            if (type == "string")
                stringList = impl == "ArrayList"
                    ? new ArrayList<string>()
                    : new Lists.LinkedList<string>();

            if (type == "MyClass")
                myClassList = impl == "ArrayList"
                    ? new ArrayList<MyClass>()
                    : new Lists.LinkedList<MyClass>();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            RefreshList();
        }
    }

    private void RefreshList()
    {
        try
        {
            listBox.Items.Clear();

            if (typeBox.SelectedItem.ToString() == "int")
            {
                foreach (var v in intList)
                    listBox.Items.Add(v);
                countLabel.Text = "Count: " + intList.Count;
            }

            if (typeBox.SelectedItem.ToString() == "string")
            {
                foreach (var v in stringList)
                    listBox.Items.Add(v);
                countLabel.Text = "Count: " + stringList.Count;
            }

            if (typeBox.SelectedItem.ToString() == "MyClass")
            {
                foreach (var v in myClassList)
                    listBox.Items.Add(v);
                countLabel.Text = "Count: " + myClassList.Count;
            }

            drawPanel.Invalidate();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                intList.Add(int.Parse(inputBox.Text));

            if (typeBox.SelectedItem.ToString() == "string")
                stringList.Add(inputBox.Text);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                myClassList.Add(new MyClass(int.Parse(inputBox.Text)));

            RefreshList();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void findAllButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
            {
                var result = ListUtils.FindAll(
                    intList,
                    x => x > int.Parse(inputBox.Text),
                    () => new ArrayList<int>());

                listBox.Items.Clear();
                foreach (var v in result)
                    listBox.Items.Add(v);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void insertButton_Click(object sender, EventArgs e)
    {
        try
        {
            int index = int.Parse(indexBox.Text);

            if (typeBox.SelectedItem.ToString() == "int")
                intList.Insert(index, int.Parse(inputBox.Text));

            if (typeBox.SelectedItem.ToString() == "string")
                stringList.Insert(index, inputBox.Text);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                myClassList.Insert(index, new MyClass(int.Parse(inputBox.Text)));
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                intList.Remove(int.Parse(inputBox.Text));

            if (typeBox.SelectedItem.ToString() == "string")
                stringList.Remove(inputBox.Text);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                myClassList.Remove(new MyClass(int.Parse(inputBox.Text)));
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }


    private void removeAtButton_Click(object sender, EventArgs e)
    {
        try
        {
            int index = int.Parse(indexBox.Text);

            if (typeBox.SelectedItem.ToString() == "int")
                intList.RemoveAt(index);

            if (typeBox.SelectedItem.ToString() == "string")
                stringList.RemoveAt(index);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                myClassList.RemoveAt(index);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                intList.Clear();

            if (typeBox.SelectedItem.ToString() == "string")
                stringList.Clear();

            if (typeBox.SelectedItem.ToString() == "MyClass")
                myClassList.Clear();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void containsButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = false;

            if (typeBox.SelectedItem.ToString() == "int")
                result = intList.Contains(int.Parse(inputBox.Text));

            if (typeBox.SelectedItem.ToString() == "string")
                result = stringList.Contains(inputBox.Text);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                result = myClassList.Contains(new MyClass(int.Parse(inputBox.Text)));

            MessageBox.Show(result.ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void subListButton_Click(object sender, EventArgs e)
    {
        try
        {
            int from = int.Parse(fromBox.Text);
            int to = int.Parse(toBox.Text);

            listBox.Items.Clear();

            if (typeBox.SelectedItem.ToString() == "int")
            {
                var sub = intList.SubList(from, to);
                foreach (var v in sub)
                    listBox.Items.Add(v);
            }

            if (typeBox.SelectedItem.ToString() == "string")
            {
                var sub = stringList.SubList(from, to);
                foreach (var v in sub)
                    listBox.Items.Add(v);
            }

            if (typeBox.SelectedItem.ToString() == "MyClass")
            {
                var sub = myClassList.SubList(from, to);
                foreach (var v in sub)
                    listBox.Items.Add(v);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void sortButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                ListUtils.Sort(intList, (a, b) => a.CompareTo(b));

            if (typeBox.SelectedItem.ToString() == "string")
                ListUtils.Sort(stringList, (a, b) => a.CompareTo(b));

            if (typeBox.SelectedItem.ToString() == "MyClass")
                ListUtils.Sort(myClassList, (a, b) => a.CompareTo(b));
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void existsButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = false;

            if (typeBox.SelectedItem.ToString() == "int")
                result = ListUtils.Exists(intList, x => x > 0);

            if (typeBox.SelectedItem.ToString() == "string")
                result = ListUtils.Exists(stringList, x => x.Length > 0);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                result = ListUtils.Exists(myClassList, x => x.Number > 0);

            MessageBox.Show(result.ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void findButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                MessageBox.Show(ListUtils.Find(intList, x => x > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "string")
                MessageBox.Show(ListUtils.Find(stringList, x => x.Length > 0));

            if (typeBox.SelectedItem.ToString() == "MyClass")
                MessageBox.Show(ListUtils.Find(myClassList, x => x.Number > 0).ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void findLastButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                MessageBox.Show(ListUtils.FindLast(intList, x => x > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "string")
                MessageBox.Show(ListUtils.FindLast(stringList, x => x.Length > 0));

            if (typeBox.SelectedItem.ToString() == "MyClass")
                MessageBox.Show(ListUtils.FindLast(myClassList, x => x.Number > 0).ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void findIndexButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                MessageBox.Show(ListUtils.FindIndex(intList, x => x > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "string")
                MessageBox.Show(ListUtils.FindIndex(stringList, x => x.Length > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "MyClass")
                MessageBox.Show(ListUtils.FindIndex(myClassList, x => x.Number > 0).ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void findLastIndexButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                MessageBox.Show(ListUtils.FindLastIndex(intList, x => x > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "string")
                MessageBox.Show(ListUtils.FindLastIndex(stringList, x => x.Length > 0).ToString());

            if (typeBox.SelectedItem.ToString() == "MyClass")
                MessageBox.Show(ListUtils.FindLastIndex(myClassList, x => x.Number > 0).ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void convertAllButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
            {
                var result = ListUtils.ConvertAll(
                    intList,
                    x => x.ToString(),
                    () => new ArrayList<string>());

                listBox.Items.Clear();
                foreach (var v in result)
                    listBox.Items.Add(v);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void forEachButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (typeBox.SelectedItem.ToString() == "int")
                ListUtils.ForEach(intList, x => MessageBox.Show(x.ToString()));
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void checkAllButton_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = false;

            if (typeBox.SelectedItem.ToString() == "int")
                result = ListUtils.CheckForAll(intList, x => x >= 0);

            if (typeBox.SelectedItem.ToString() == "string")
                result = ListUtils.CheckForAll(stringList, x => x.Length > 0);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                result = ListUtils.CheckForAll(myClassList, x => x.Number >= 0);

            MessageBox.Show(result.ToString());
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }

    private void indexOfButton_Click(object sender, EventArgs e)
    {
        try
        {
            int result = -1;

            if (typeBox.SelectedItem.ToString() == "int")
                result = intList.IndexOf(int.Parse(inputBox.Text));

            if (typeBox.SelectedItem.ToString() == "string")
                result = stringList.IndexOf(inputBox.Text);

            if (typeBox.SelectedItem.ToString() == "MyClass")
                result = myClassList.IndexOf(new MyClass(int.Parse(inputBox.Text)));

            MessageBox.Show("Index: " + result);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            RefreshList();
        }
    }
}