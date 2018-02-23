using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace XamarinApp.behaviors
{
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        //Método responsável por vincular o evento de "TextChanged" ao Entry
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(bindable);
        }

        //Método responsável por desvincular o evento de "TextChanged" ao Entry
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(bindable);
        }

        //Método responsável por executar a validação do campo
        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase);

            Entry entry = sender as Entry;
            entry.TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
