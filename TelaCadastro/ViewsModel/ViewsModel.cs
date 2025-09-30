using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TelaCadastro.Model;

namespace TelaCadastro.ViewsModel
{
    internal class ViewsModel
    { 

        // O ViewModel conecta os dados (Model) com a tela (View).
      // Ele implementa INotifyPropertyChanged para avisar a tela quando algo mudar.
        public class CadastroViewModel : INotifyPropertyChanged
        {
            private Usuario _usuario = new Usuario();   // Armazena os dados do usuário
            private bool _aceitouTermos;                // Marca se aceitou os termos
            private bool _naoSouRobo;                   // Marca se marcou "não sou robô"

            // Propriedade exposta para a View (ligada ao Model Usuario)
            public Usuario Usuario
            {
                get => _usuario;                       // Retorna o valor
                set { _usuario = value; OnPropertyChanged(); } // Atualiza e notifica a View
            }

            // Propriedade ligada ao CheckBox "Aceitou Termos"
            public bool AceitouTermos
            {
                get => _aceitouTermos;
                set { _aceitouTermos = value; OnPropertyChanged(); }
            }

            // Propriedade ligada ao CheckBox "Não sou robô"
            public bool NaoSouRobo
            {
                get => _naoSouRobo;
                set { _naoSouRobo = value; OnPropertyChanged(); }
            }

            // Comando que será executado quando clicar no botão "Cadastrar"
            public ICommand CadastrarCommand { get; }

            // Construtor: define o que acontece quando criamos o ViewModel
            public CadastroViewModel()
            {
                // Cria um novo comando, passando o método de ação (Cadastrar)
                // e a condição para habilitar o botão (PodeCadastrar)
                CadastrarCommand = new RelayCommand(Cadastrar, PodeCadastrar);
            }

            // Método que será executado quando clicar no botão
            private void Cadastrar()
            {
                // Como o RelayCommand espera um método Action (sem retorno), removemos o uso de async/await
                Application.Current.MainPage.DisplayAlert("Sucesso", $"Usuário {Usuario.Nome} cadastrado com sucesso!", "OK");
            }

            // Define se o botão "Cadastrar" pode ser clicado
            private bool PodeCadastrar()
            {
                // Só deixa cadastrar se aceitou os termos E marcou que não é robô
                return AceitouTermos && NaoSouRobo;
            }

            // Evento necessário para atualizar a interface quando algo muda
            public event PropertyChangedEventHandler PropertyChanged;

            // Método que dispara a notificação de mudança
            protected void OnPropertyChanged([CallerMemberName] string nome = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
            }
        }

        // Classe auxiliar RelayCommand: usada para associar comandos a botões
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;       // Ação a ser executada
            private readonly Func<bool> _canExecute; // Função que define se pode executar

            // Construtor recebe a ação e a condição
            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            // Evento disparado quando o estado de execução muda (habilita/desabilita botão)
            public event EventHandler CanExecuteChanged;

            // Define se o comando pode rodar
            public bool CanExecute(object parameter) => _canExecute();

            // Executa a ação
            public void Execute(object parameter) => _execute();

            // Método para forçar atualização da condição
            public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }


}
