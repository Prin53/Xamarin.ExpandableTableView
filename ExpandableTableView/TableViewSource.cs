using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace ExpandableTableView
{
    public class TableViewSource<TGroup, TItem> : UITableViewSource
    {
        private IDictionary<NSIndexPath, string> _expandedRows;

        private NSIndexPath _indexPathOfSelectedRow;

        private IEnumerable<IGrouping<TGroup, TItem>> _items;

        public IEnumerable<IGrouping<TGroup, TItem>> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;

                TableView.ReloadData();
            }
        }

        protected string CellIdentifier
        {
            get;
        }

        protected string HeaderIdentifier
        {
            get;
        }

        protected UITableView TableView
        {
            get;
        }

        public TableViewSource(UITableView tableView)
        {
            TableView = tableView;

            var cellType = typeof(TableViewCell);
            var headerType = typeof(TableViewHeaderFooterView);

            CellIdentifier = cellType.Name;
            HeaderIdentifier = headerType.Name;

            TableView.RegisterClassForCellReuse(cellType, CellIdentifier);
            TableView.RegisterClassForHeaderFooterViewReuse(headerType, HeaderIdentifier);

            _expandedRows = new Dictionary<NSIndexPath, string>();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as TableViewCell;

            cell.Bind(Items.ElementAt(indexPath.Section).ElementAt(indexPath.Row));

            cell.IsExpanded = _expandedRows.ContainsKey(indexPath);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (_expandedRows.ContainsKey(indexPath))
            {
                _expandedRows.Remove(indexPath);
            }
            else
            {
                _expandedRows.Add(indexPath, string.Empty);
            }

            _indexPathOfSelectedRow = indexPath;

            TableView.ReloadRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            (cell as TableViewCell).UpdateIndicator(_indexPathOfSelectedRow == indexPath);

            if (_indexPathOfSelectedRow == indexPath)
            {
                _indexPathOfSelectedRow = null;
            }
        }

        //public override string TitleForHeader(UITableView tableView, nint section) => Items?.ElementAt((int)section).Key.ToString() ?? null;

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var header = tableView.DequeueReusableHeaderFooterView(HeaderIdentifier) as TableViewHeaderFooterView;

            header.Bind(Items.ElementAt((int)section).Key);

            return header;
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section) => UITableView.AutomaticDimension;

        public override nfloat EstimatedHeightForHeader(UITableView tableView, nint section) => 44;

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath) => UITableView.AutomaticDimension;

        public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath) => 140;

        public override nint NumberOfSections(UITableView tableView) => Items?.Count() ?? 0;

        public override nint RowsInSection(UITableView tableview, nint section) => Items?.ElementAt((int)section).Count() ?? 0;
    }
}
