using System.Linq;
using Xamarin.Forms;

// ReSharper disable once CheckNamespace
namespace Binding101
{
    public class UppercaseRedBehavior : Behavior<Entry>
    {
        private Entry _associatedEntry;
        private Color _defaultColor;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            _associatedEntry = bindable;
            _associatedEntry.TextChanged += EntryTextChanged;
            _defaultColor = _associatedEntry.TextColor;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            _associatedEntry.TextColor = _defaultColor;
            _associatedEntry.TextChanged -= EntryTextChanged;
            _associatedEntry = null;
        }

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            _associatedEntry.TextColor = 
                _associatedEntry.Text.All(char.IsUpper) ? Color.Red : _defaultColor;
        }
    }
}