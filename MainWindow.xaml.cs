using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Data;
using OfficeOpenXml;
using System.IO;
using System.Data.Common;

namespace BrighterShoresCalculator
{
    public partial class MainWindow : Window
    {

        private Dictionary<int, int> levelValues = new Dictionary<int, int>
        {
            { 1, 500 },
            { 2, 1015 },
            { 3, 1545 },
            { 4, 2090 },
            { 5, 2651 },
            { 6, 3229 },
            { 7, 4418 },
            { 8, 5642 },
            { 9, 6902 },
            { 10, 8199 },
            { 11, 9534 },
            { 12, 10908 },
            { 13, 13736 },
            { 14, 16647 },
            { 15, 19644 },
            { 16, 22728 },
            { 17, 25903 },
            { 18, 29171 },
            { 19, 32535 },
            { 20, 35997 },
            { 21, 53815 },
            { 22, 71979 },
            { 23, 90496 },
            { 24, 109373 },
            { 25, 128617 },
            { 26, 148236 },
            { 27, 168236 },
            { 28, 188625 },
            { 29, 209410 },
            { 30, 230599 },
            { 31, 252200 },
            { 32, 274221 },
            { 33, 296670 },
            { 34, 319556 },
            { 35, 342887 },
            { 36, 366671 },
            { 37, 390918 },
            { 38, 415636 },
            { 39, 440834 },
            { 40, 466522 },
            { 41, 492710 },
            { 42, 519407 },
            { 43, 546623 },
            { 44, 574368 },
            { 45, 602652 },
            { 46, 631486 },
            { 47, 660881 },
            { 48, 690847 },
            { 49, 721396 },
            { 50, 752539 },
            { 51, 784287 },
            { 52, 816652 },
            { 53, 849646 },
            { 54, 883282 },
            { 55, 917572 },
            { 56, 952528 },
            { 57, 988164 },
            { 58, 1024493 },
            { 59, 1061528 },
            { 60, 1099283 },
            { 61, 1137772 },
            { 62, 1177009 },
            { 63, 1217009 },
            { 64, 1257787 },
            { 65, 1299357 },
            { 66, 1341736 },
            { 67, 1384938 },
            { 68, 1428980 },
            { 69, 1473878 },
            { 70, 1519649 },
            { 71, 1566310 },
            { 72, 1613878 },
            { 73, 1662371 },
            { 74, 1711807 },
            { 75, 1762204 },
            { 76, 1813581 },
            { 77, 1865956 },
            { 78, 1919350 },
            { 79, 1973782 },
            { 80, 2029272 },
            { 81, 2085841 },
            { 82, 2143509 },
            { 83, 2202298 },
            { 84, 2262230 },
            { 85, 2323327 },
            { 86, 2385612 },
            { 87, 2449108 },
            { 88, 2513838 },
            { 89, 2579827 },
            { 90, 2647099 },
            { 91, 2715679 },
            { 92, 2785592 },
            { 93, 2856864 },
            { 94, 2929521 },
            { 95, 3003591 },
            { 96, 3079101 },
            { 97, 3156079 },
            { 98, 3234553 },
            { 99, 3314553 },
            { 100, 3396108 },
            { 101, 3479249 },
            { 102, 3564006 },
            { 103, 3650411 },
            { 104, 3738496 },
            { 105, 3828293 },
            { 106, 3919836 },
            { 107, 4013158 },
            { 108, 4108295 },
            { 109, 4205281 },
            { 110, 4304153 },
            { 111, 4404947 },
            { 112, 4507700 },
            { 113, 4612451 },
            { 114, 4719238 },
            { 115, 4828101 },
            { 116, 4939081 },
            { 117, 5052218 },
            { 118, 5167555 },
            { 119, 5285134 },
            { 120, 5404999 },
            { 121, 5527194 },
            { 122, 5651764 },
            { 123, 5778756 },
            { 124, 5908217 },
            { 125, 6040195 },
            { 126, 6174738 },
            { 127, 6311897 },
            { 128, 6451723 },
            { 129, 6594267 },
            { 130, 6739582 },
            { 131, 6887722 },
            { 132, 7038742 },
            { 133, 7192698 },
            { 134, 7349647 },
            { 135, 7509647 },
            { 136, 7672757 },
            { 137, 7839039 },
            { 138, 8008553 },
            { 139, 8181363 },
            { 140, 8357532 },
            { 141, 8537126 },
            { 142, 8720211 },
            { 143, 8906856 },
            { 144, 9097129 },
            { 145, 9291101 },
            { 146, 9488844 },
            { 147, 9690431 },
            { 148, 9895937 },
            { 149, 10105439 },
            { 150, 10319013 },
            { 151, 10536739 },
            { 152, 10758698 },
            { 153, 10984972 },
            { 154, 11215645 },
            { 155, 11450803 },
            { 156, 11690532 },
            { 157, 11934922 },
            { 158, 12184063 },
            { 159, 12438047 },
            { 160, 12696969 },
            { 161, 12960924 },
            { 162, 13230011 },
            { 163, 13504329 },
            { 164, 13783980 },
            { 165, 14069068 },
            { 166, 14359698 },
            { 167, 14655978 },
            { 168, 14958018 },
            { 169, 15265930 },
            { 170, 15579828 },
            { 171, 15899828 },
            { 172, 16226049 },
            { 173, 16558612 },
            { 174, 16897640 },
            { 175, 17243259 },
            { 176, 17595597 },
            { 177, 17954785 },
            { 178, 18320956 },
            { 179, 18694245 },
            { 180, 19074791 },
            { 181, 19462735 },
            { 182, 19858221 },
            { 183, 20261396 },
            { 184, 20672409 },
            { 185, 21091412 },
            { 186, 21518561 },
            { 187, 21954014 },
            { 188, 22397932 },
            { 189, 22850480 },
            { 190, 23311826 },
            { 191, 23782141 },
            { 192, 24261599 },
            { 193, 24750378 },
            { 194, 25248660 },
            { 195, 25756628 },
            { 196, 26274471 },
            { 197, 26802382 },
            { 198, 27340556 },
            { 199, 27889192 },
            { 200, 28448494 }
        };

        public MainWindow()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

            DisclaimerWindow();

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DisclaimerWindow()
        {
            string disclaimerMessage = "Thank you for using the Brighter Shores EXP Calculator." + System.Environment.NewLine + "This app currently only supports up to Level 200." + System.Environment.NewLine + "As new data is retrieved in the game, this app will be updated." + System.Environment.NewLine + "Thank you for your support";
            string caption = "Disclaimer";

            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.None;
            MessageBoxResult result;

            if (App.Current.MainWindow.IsVisible)
            {
                result = MessageBox.Show(disclaimerMessage, caption, button, icon, MessageBoxResult.Yes);
            } else
            {
                App.Current.MainWindow.Show();
                result = MessageBox.Show(disclaimerMessage, caption, button, icon, MessageBoxResult.Yes);
            }

            
        }

        private void LevelTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_expToNext == null)
            {
                return;
            }

            string val = _sliderValue.Text;

            if (val == "")
            {
            }
            else
            {
                _levelSlider.Value = int.Parse(val);
                
                if (int.TryParse(_sliderValue.Text, out int level))
                {
                    if (levelValues.TryGetValue(level, out int value))
                    {
                        int currentExp;

                        if(_currentExp.Text == "")
                        {
                            currentExp = 0;
                        }
                        else
                        {
                            currentExp = int.Parse(_currentExp.Text);
                        }

                        _expToNext.Text = (value - currentExp).ToString();

                        GetActiveTab();
                    }
                }
            }
        }

        private void ExpUpdate(object sender, TextChangedEventArgs e)
        {
            LevelTextChanged(sender, e);
        }

        private void GetActiveTab()
        {
            TabItem selectedOuterTab = MainTabControl.SelectedItem as TabItem;
            if (selectedOuterTab != null)
            {
                if (selectedOuterTab.Content is Grid outerGrid)
                {
                    TabControl nestedTabControl = outerGrid.Children
                        .OfType<TabControl>()
                        .FirstOrDefault();

                    if (nestedTabControl != null)
                    {
                        TabItem selectedInnerTab = nestedTabControl.SelectedItem as TabItem;
                        if (selectedInnerTab != null)
                        {
                            string tabName = selectedInnerTab.Header.ToString();

                            UpdateActions(tabName);
                        }
                    }
                }
            }
        }

        private void UpdateActions(string tabName)
        {
            switch (tabName)
            {
                case "Guard":
                    int columnNumber = 5;
                    ProcessColumn5Values(guardDataGrid, columnNumber);
                    break;
                case "Chef":
                    columnNumber = 6;
                    ProcessColumn5Values(chefDataGrid, columnNumber);
                    break;
                case "Fisher":
                    columnNumber = 4;
                    ProcessColumn5Values(fisherDataGrid, columnNumber);
                    break;
                case "Forager":
                    columnNumber = 4;
                    ProcessColumn5Values(foragerDataGrid, columnNumber);
                    break;
                case "Alchemist":
                    columnNumber = 11;
                    ProcessColumn5Values(alchemistDataGrid, columnNumber);
                    break;
                case "Scout":
                    columnNumber = 5;
                    ProcessColumn5Values(scoutDataGrid, columnNumber);
                    break;
                case "Gatherer":
                    columnNumber = 4;
                    ProcessColumn5Values(gathererDataGrid, columnNumber);
                    break;
                case "Woodcutter":
                    columnNumber = 3;
                    ProcessColumn5Values(woodcutterDataGrid, columnNumber);
                    break;
                case "Carpenter":
                    columnNumber = 8;
                    ProcessColumn5Values(carpenterDataGrid, columnNumber);
                    break;
                case "Minefighter":
                    columnNumber = 5;
                    ProcessColumn5Values(minefighterDataGrid, columnNumber);
                    break;
                case "Bonewright":
                    columnNumber = 6;
                    ProcessColumn5Values(bonewrightDataGrid, columnNumber);
                    break;
                case "Miner":
                    columnNumber = 4;
                    ProcessColumn5Values(minerDataGrid, columnNumber);
                    break;
                case "Blacksmith":
                    columnNumber = 6;
                    ProcessColumn5Values(blacksmithDataGrid, columnNumber);
                    break;
                case "Stonemason":
                    columnNumber = 5;
                    ProcessColumn5Values(stonemasonDataGrid, columnNumber);
                    break;
                case "Watchperson":
                    columnNumber = 5;
                    ProcessColumn5Values(watchpersonDataGrid, columnNumber);
                    break;
                case "Detective":
                    columnNumber = 4;
                    ProcessColumn5Values(detectiveDataGrid, columnNumber);
                    break;
                case "Leatherworker":
                    columnNumber = 6;
                    ProcessColumn5Values(leatherworkerDataGrid, columnNumber);
                    break;
                case "Merchant":
                    columnNumber = 5;
                    ProcessColumn5Values(merchantDataGrid, columnNumber);
                    break;

            }

        }

        private void ProcessColumn5Values(DataGrid dataGrid, int column)
        {
            if (dataGrid.ItemsSource is DataView dataView)
            {
                DataTable dataTable = dataView.Table;

                if (column < 0 || column >= dataTable.Columns.Count)
                {
                    return;
                }

                // Get the value of _expToNext as an integer
                if (!int.TryParse(_expToNext.Text, out int expToNextValue))
                {
                    return;
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    var columnValue = row[column];

                    // Check if the columnValue is not null or DBNull
                    if (columnValue != DBNull.Value && int.TryParse(columnValue.ToString(), out int intColumnValue))
                    {
                        // Perform the division
                        double result = Math.Ceiling((double)expToNextValue / intColumnValue);

                        var outputColumn = column + 1;

                        row[outputColumn] = (int)result;
                    }
                    else
                    {
                        Console.WriteLine($"Row {dataTable.Rows.IndexOf(row)}: Invalid column value.");
                    }
                }
            }
            else
            {
                Console.WriteLine("DataGrid ItemsSource is not a valid DataView.");
            }
        }

        private void ResetValues(object sender, MouseButtonEventArgs e)
        {
           _levelSlider.Value = 1;
            _currentExp.Text = "0";
            _expToNext.Text = "500";
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databasesFolder = "Databases";
            string fileName;
            string filePath;

            List<string> professions = new List<string>
            {
                "Guard","Chef","Fisher","Forager","Alchemist","Scout","Gatherer","Woodcutter","Carpenter","Minefighter","Bonewright","Miner","Blacksmith","Stonemason","Watchperson","Detective","Leatherworker","Merchant"
            };

            foreach (string prof in professions)
            {
                switch (prof)
                {
                    case "Guard":
                        fileName = "Guard Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);

                        DataTable dataTable1 = ReadExcelFile(filePath, prof);

                        guardDataGrid.ItemsSource = dataTable1.DefaultView;
                        break;
                    case "Chef":
                        fileName = "Chef Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable2 = ReadExcelFile(filePath, prof);

                        chefDataGrid.ItemsSource = dataTable2.DefaultView;
                        break;
                    case "Fisher":
                        fileName = "Fisher Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable3 = ReadExcelFile(filePath, prof);

                        fisherDataGrid.ItemsSource = dataTable3.DefaultView;
                        break;
                    case "Forager":
                        fileName = "Forager Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable4 = ReadExcelFile(filePath, prof);

                        foragerDataGrid.ItemsSource = dataTable4.DefaultView;
                        break;
                    case "Alchemist":
                        fileName = "Alchemist Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable5 = ReadExcelFile(filePath, prof);

                        alchemistDataGrid.ItemsSource = dataTable5.DefaultView;
                        break;
                    case "Scout":
                        fileName = "Scout Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable6 = ReadExcelFile(filePath, prof);

                        scoutDataGrid.ItemsSource = dataTable6.DefaultView;
                        break;
                    case "Gatherer":
                        fileName = "Gatherer Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable7 = ReadExcelFile(filePath, prof);

                        gathererDataGrid.ItemsSource = dataTable7.DefaultView;
                        break;
                    case "Woodcutter":
                        fileName = "Woodcutter Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable8 = ReadExcelFile(filePath, prof);

                        woodcutterDataGrid.ItemsSource = dataTable8.DefaultView;
                        break;
                    case "Carpenter":
                        fileName = "Carpentry Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable9 = ReadExcelFile(filePath, prof);

                        carpenterDataGrid.ItemsSource = dataTable9.DefaultView;
                        break;
                    case "Minefighter":
                        fileName = "Minefighter Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable10 = ReadExcelFile(filePath, prof);

                        minefighterDataGrid.ItemsSource = dataTable10.DefaultView;
                        break;
                    case "Bonewright":
                        fileName = "Bonewright Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable11 = ReadExcelFile(filePath, prof);

                        bonewrightDataGrid.ItemsSource = dataTable11.DefaultView;
                        break;
                    case "Miner":
                        fileName = "Miner Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable12 = ReadExcelFile(filePath, prof);

                        minerDataGrid.ItemsSource = dataTable12.DefaultView;
                        break;
                    case "Blacksmith":
                        fileName = "Blacksmith Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable13 = ReadExcelFile(filePath, prof);

                        blacksmithDataGrid.ItemsSource = dataTable13.DefaultView;
                        break;
                    case "Stonemason":
                        fileName = "Stonemason Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable14 = ReadExcelFile(filePath, prof);

                        stonemasonDataGrid.ItemsSource = dataTable14.DefaultView;
                        break;
                    case "Watchperson":
                        fileName = "Watchperson Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable15 = ReadExcelFile(filePath, prof);

                        watchpersonDataGrid.ItemsSource = dataTable15.DefaultView;
                        break;
                    case "Detective":
                        fileName = "Detective Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable16 = ReadExcelFile(filePath, prof);

                        detectiveDataGrid.ItemsSource = dataTable16.DefaultView;
                        break;
                    case "Leatherworker":
                        fileName = "Leatherworking Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable17 = ReadExcelFile(filePath, prof);

                        leatherworkerDataGrid.ItemsSource = dataTable17.DefaultView;
                        break;
                    case "Merchant":
                        fileName = "Merchant Database.xlsx";
                        filePath = Path.Combine(baseDirectory, databasesFolder, fileName);
                        DataTable dataTable18 = ReadExcelFile(filePath, prof);

                        merchantDataGrid.ItemsSource = dataTable18.DefaultView;
                        break;
                }
            }

        }

        private DataTable ReadExcelFile(string filePath, string profession)
        {
            DataTable dataTable = new DataTable();

            // Open the Excel package using EPPlus
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Check if there are any worksheets
                if (package.Workbook.Worksheets.Count == 0)
                {
                    MessageBox.Show("The Excel file does not contain any worksheets.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return dataTable;  // Return an empty DataTable
                }

                // Get the first worksheet (make sure it exists)
                var worksheet = package.Workbook.Worksheets[0];  // Accessing the first worksheet

                // Add columns to DataTable (first row contains column names)
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                }

                // Add rows to DataTable (data starts from second row)
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var dataRow = dataTable.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    } 
}