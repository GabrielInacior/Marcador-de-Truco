using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarcadorTruco
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private int _equipe1Pontos;
        private int _equipe2Pontos;
        private int ponto = 1;
        private int aux2 = 2;

        public int Equipe1Pontos
        {
            get { return _equipe1Pontos; }
            set
            {
                if (_equipe1Pontos != value)
                {
                    _equipe1Pontos = value;
                    OnPropertyChanged(nameof(Equipe1Pontos));

                    if (_equipe1Pontos >= 12)
                    {
                        MensagemVitoria();
                        Equipe1Pontos = 0;
                    }
                }
            }
        }

        public int Equipe2Pontos
        {
            get { return _equipe2Pontos; }
            set
            {
                if (_equipe2Pontos != value)
                {
                    _equipe2Pontos = value;
                    OnPropertyChanged(nameof(Equipe2Pontos));

                    if (_equipe2Pontos >= 12)
                    {
                        MensagemVitoria();
                        Equipe2Pontos = 0;
                    }
                }
            }
        }

        private string _textoPessoa1;

        public string TextoPessoa1
        {
            get { return _textoPessoa1; }
            set
            {
                if (_textoPessoa1 != value)
                {
                    _textoPessoa1 = value;
                    OnPropertyChanged(nameof(TextoPessoa1));
                }
            }
        }

        private string _textoPessoa2;

        public string TextoPessoa2
        {
            get { return _textoPessoa2; }
            set
            {
                if (_textoPessoa2 != value)
                {
                    _textoPessoa2 = value;
                    OnPropertyChanged(nameof(TextoPessoa1));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Button_Clicked(object sender, EventArgs e)
        {   
            if(Equipe1Pontos < 12)
            {
                Equipe1Pontos+= ponto;
            }
            else if (Equipe1Pontos >= 12)
            {
                Equipe1Pontos = 0;
            }
          
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {   
            if(Equipe1Pontos == 0)
            {
                Equipe1Pontos = 0;
            }
            else
            {
                Equipe1Pontos--;
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (Equipe2Pontos < 12)
            {
                Equipe2Pontos += ponto;
            }
            else if (Equipe2Pontos >=12)
            {
                Equipe2Pontos = 0;
           
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {

            if (Equipe2Pontos == 0)
            {
                Equipe2Pontos = 0;
            }
            else
            {
                Equipe2Pontos--;
            }
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
           
            if (ponto >= 12)
            {
                ponto = 1;
            }
            else
            {
                if (ponto >= 3)
                {
                    aux2 = 3;
                    ponto += aux2;
                }
                else
                {
                    aux2 = 2;
                    ponto += aux2;
                }
            }
           string aux = Convert.ToString(ponto);
            btnEquipe1.Text = $"+{aux}";
            btnEquipe2.Text = $"+{aux}";

        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Equipe1Pontos = 0;
            Equipe2Pontos = 0;
            ponto = 1;

            string aux = Convert.ToString(ponto);

            btnEquipe1.Text = $"+{aux}";
            btnEquipe2.Text = $"+{aux}";

            Entry1.Text = string.Empty;
            Entry1.Placeholder = "Equipe 1";

            Entry2.Text = string.Empty;
            Entry2.Placeholder = "Equipe 2";
        }
        private async void MensagemVitoria()
        {
            if(Equipe1Pontos >= 12)
            {
                var animatedAlert = new CustomAlert("Vitória", $"{TextoPessoa2} perdeu, seu pato!", "https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExdGpqN3gwNWFpdXdqYnRmN3E2M256NjZvNnJ2MzJkY3E5eHdiMmUzMiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/azUl0qKaJ8X6NlhKdE/giphy.gif");
                await Navigation.PushModalAsync(new NavigationPage(animatedAlert));
            }
            else if (Equipe2Pontos >= 12)
            {
                var animatedAlert = new CustomAlert("Vitória", $"{TextoPessoa1} perdeu, seu pato!", "https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExdGpqN3gwNWFpdXdqYnRmN3E2M256NjZvNnJ2MzJkY3E5eHdiMmUzMiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/azUl0qKaJ8X6NlhKdE/giphy.gif");
                await Navigation.PushModalAsync(new NavigationPage(animatedAlert));
            }
        }
    }
}
