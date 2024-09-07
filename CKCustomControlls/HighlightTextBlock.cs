using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CKCustomControlls
{
    [TemplatePart(Name = TEXT_DISPLAY_PART_NAME, Type = typeof(TextBlock))]
    public class HighlightTextBlock : Control
    {

        #region Fields
        private const string TEXT_DISPLAY_PART_NAME = "PART_TextDisplay";
        private TextBlock _displayTextBlock;

        #endregion

        #region DependencyProperties
        public string HighlightText
        {
            get { return (string)GetValue(HighlightTextProperty); }
            set { SetValue(HighlightTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighlightTextProperty =
           DependencyProperty.Register(nameof(HighlightText), typeof(string), typeof(HighlightTextBlock), new PropertyMetadata(string.Empty, OnHighlightTextPropertyChanged));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
          TextBlock.TextProperty.AddOwner(typeof(HighlightTextBlock), new PropertyMetadata(string.Empty, OnHighlightTextPropertyChanged));

        #endregion

        #region Ctor
        static HighlightTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HighlightTextBlock), new FrameworkPropertyMetadata(typeof(HighlightTextBlock)));
        }

        #endregion

        #region override 

        public override void OnApplyTemplate()
        {
            _displayTextBlock = Template.FindName(TEXT_DISPLAY_PART_NAME, this) as TextBlock;
            UpdateHighlightDisplay();
            base.OnApplyTemplate();
        }

        #endregion

        #region private Methods


        private void UpdateHighlightDisplay()
        {
            if (_displayTextBlock != null)
            {
                _displayTextBlock.Inlines.Clear();

                int highlightTextLenght = HighlightText.Length;
                if (highlightTextLenght == 0)
                {
                    _displayTextBlock.Text = Text;
                }
                else
                {
                    for (int i = 0; i < Text.Length; i++)
                    {
                        if (i + highlightTextLenght > Text.Length)
                        {
                            _displayTextBlock.Inlines.Add(new Run(Text.Substring(i)));
                            break;
                        }

                        int nextHighlightTextIndex = Text.IndexOf(HighlightText, i);
                        if (nextHighlightTextIndex == -1)
                        {
                            _displayTextBlock.Inlines.Add(new Run(Text.Substring(i)));
                            break;
                        }

                        _displayTextBlock.Inlines.Add(new Run(Text.Substring(i, nextHighlightTextIndex - i)));
                        _displayTextBlock.Inlines.Add(CreateHighlightedRun(HighlightText));

                        i = nextHighlightTextIndex + highlightTextLenght - 1;

                    }
                }
            }
        }


        private static void OnHighlightTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is HighlightTextBlock highlightTextBlock)
            {
                highlightTextBlock.UpdateHighlightDisplay();
            }
        }


        private Run CreateHighlightedRun(string text)
        {
            Style style = new Style(typeof(Run));
            style.Setters.Add(new Setter(Run.BackgroundProperty, Brushes.Yellow));
            return new Run(text)
            {
                Style = style
            };
        }


        #endregion
    }
}