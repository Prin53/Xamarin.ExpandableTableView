using System;
using UIKit;

namespace ExpandableTableView
{
    public class TableViewHeaderFooterView : UITableViewHeaderFooterView
    {
        protected UILabel TitleLabel
        {
            get;
        }

        public TableViewHeaderFooterView(IntPtr handle) : base(handle)
        {
            TitleLabel = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            ContentView.AddSubviews(TitleLabel);

            ContentView.AddConstraints(new[]
            {
                TitleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, 16),
                TitleLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor, -16),
                TitleLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
                TitleLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16)
            });
        }

        public void Bind(object item)
        {
            TitleLabel.Text = item.ToString(); 
        }
    }
}
