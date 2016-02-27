using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NPGui.Controls
{
    /// <summary>
    /// Interaction logic for DynamicTabsControl.xaml
    /// </summary>
    public partial class DynamicTabsControl : UserControl
    {
        public List<TabItem> _tabItems;
        //private TabItem _tabAdd;
        //public Type newTab = typeof(TextBox);


        #region PROPERTIES
        /*
        * NEXT TAB DATAS
        */
        //Type name
        public static readonly DependencyProperty NextTabCreateProperty = DependencyProperty.RegisterAttached("NextTabType",
           typeof(string), typeof(DynamicTabsControl), new FrameworkPropertyMetadata(null));

        public static string GetNextTabCreateProperty(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (string)element.GetValue(NextTabCreateProperty);
        }
        public static void SetNextTabCreateProperty(UIElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(NextTabCreateProperty, value);
        }
        
        //Tab name
        public static readonly DependencyProperty NextTabNameProperty = DependencyProperty.RegisterAttached("NextTabName",
                                         typeof(string), typeof(DynamicTabsControl), new FrameworkPropertyMetadata(null));
    
        public static string GetNextTabNameProperty(UIElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            return (string)element.GetValue(NextTabNameProperty);
        }
        public static void SeNextTabNameProperty(UIElement element, string value)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            element.SetValue(NextTabNameProperty, value);
        }
        #endregion PROPERTIES

        public DynamicTabsControl()
        {
            // newTab = typeof(ImageWorkspaceControl);
         
            try
            {
                InitializeComponent();

                // initialize tabItem array
                _tabItems = new List<TabItem>();

                // add a tabItem with + in header 
                TabItem tabAdd = new TabItem();
                tabAdd.Header = "+";

                _tabItems.Add(tabAdd);


                //// bind tab control
                tabDynamic.DataContext = _tabItems;

                tabDynamic.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TabItem _addTabItem(Control control)
        {
            int count = _tabItems.Count;

            // tab NAME
            string tName = string.Format("Tab {0}", count);

            string dpName = GetNextTabNameProperty(this);
            if (dpName != null)
            {
                tName = dpName;
            }

            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = tName;
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;

            // add controls to tab item, this case I added just a textbox
            var txt = control;// new TextBox();
            txt.Name = "txt";
            tab.Content = txt;

            // insert tab item right before the last (+) tab item
            _tabItems.Insert(count - 1, tab);
            return tab;
        }

        public void DeleteTab(string name)
        {
            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(name)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (_tabItems.Count < 3)
                {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // get selected tab
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    _tabItems.Remove(tab);

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
        }

        public void RenameTab(string name, string newName)
        {
            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(name)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {

                // get selected tab
                TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                selectedTab.Header = newName;
            }
   
        }

        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh(null);
        }
        public bool forceNew = false;
        public void refresh(Control control)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;

            if (tab != null && tab.Header != null)
            {
                if (tab.Header.Equals("+") || forceNew)
                {
                    forceNew = false;
                    // clear tab control binding
                    tabDynamic.DataContext = null;

                    if(control == null)
                    {
                        string propV = (string)GetNextTabCreateProperty(this);
                        Type t = Type.GetType(propV);
                        control = (Control)Activator.CreateInstance(t);
                    }
                  
                    // add new tab
                    TabItem newTab = this._addTabItem(control);

                    // bind tab control
                    tabDynamic.DataContext = _tabItems;

                    // select newly added tab item
                    tabDynamic.SelectedItem = newTab;
                }
                else
                {
                    // your code here...
                }
            }
        }

        public void AddNewTab(Control control)
        {
            forceNew = true;
            refresh(control);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();
            DeleteTab(tabName);
        }
    }
}
