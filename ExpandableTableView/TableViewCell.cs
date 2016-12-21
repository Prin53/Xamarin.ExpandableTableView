using System;
using UIKit;

namespace ExpandableTableView
{
    public class TableViewCell : UITableViewCell
    {
        private bool _isExpanded;

        protected NSLayoutConstraint DetailLabelHeightConstraint
        {
            get;
            set;
        }

        protected UILabel TitleLabel
        {
            get;
        }

        protected UILabel DetailLabel
        {
            get;
        }

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;

                DetailLabelHeightConstraint.Active = !_isExpanded;
            }
        }

        public TableViewCell(IntPtr handle) : base(handle)
        {
            TitleLabel = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };

            DetailLabel = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };

            ContentView.AddSubviews(TitleLabel, DetailLabel);

            ContentView.AddConstraints(new []
            {
                TitleLabel.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, 16),
                TitleLabel.BottomAnchor.ConstraintEqualTo(DetailLabel.TopAnchor, -16),
                TitleLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
                TitleLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
                DetailLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
                DetailLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
                DetailLabel.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor, -16),
                DetailLabelHeightConstraint = DetailLabel.HeightAnchor.ConstraintEqualTo(0),
            });
        }

        public void Bind(object item)
        {
            TitleLabel.Text = item.ToString();
            DetailLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
        }
    }
}
