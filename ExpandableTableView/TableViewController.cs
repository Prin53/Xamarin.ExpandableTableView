using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace ExpandableTableView
{
    public class TableViewController : UITableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableViewSource<int, int>(TableView);

            var items = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                items.Add(i);
            }

            source.Items = items.GroupBy(item => 10 * ((item + 9) / 10));

            TableView.Source = source;
        }
    }
}
