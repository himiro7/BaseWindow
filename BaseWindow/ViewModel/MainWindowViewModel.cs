using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using BaseWindow.Message;

namespace BaseWindow.ViewModel
{
  /// <summary>
  /// メインウィンドウのViewModel
  /// </summary>
  public class MainWindowViewModel : NotificationObject
  {
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public MainWindowViewModel()
    {
    }

    private string _TestText;
    public string TestText
    {
      get { return _TestText; }
      set
      {
        _TestText = value;
        RaisePropertyChanged(() => TestText);
      }
    }

    private DelegateCommand _OpenFile;
    public DelegateCommand OpenFile
    {
      get
      {
        return this._OpenFile = this._OpenFile ??
          new DelegateCommand(openFile);
      }
    }

    private void openFile()
    {
      TestText = "open file!!";

      OpenFileRequest.Raise(new Confirmation { Title="", Content=new FileMessage()},
        (confirmation) =>
        {
          if( confirmation.Confirmed )
          {
            var fileMessage = confirmation.Content as FileMessage;
            TestText = fileMessage.FileName;
          }
        }
        );
    }

    private DelegateCommand _saveFile;
    public DelegateCommand SaveFile
    {
      get
      {
        return this._saveFile = this._saveFile ??
          new DelegateCommand(saveFile);
      }
    }

    private void saveFile()
    {
      TestText = "save File!!";

      SaveFileRequest.Raise(new Confirmation { Title = "", Content = new FileMessage() },
        (confirmation) =>
          {
            if (confirmation.Confirmed)
            {
              var fileMessage = confirmation.Content as FileMessage;
              TestText = fileMessage.FileName;
            }
          }
        );
    }

    private DelegateCommand _SelectFolder;
    public DelegateCommand SelectFolder
    {
      get
      {
        return this._SelectFolder= this._SelectFolder ??
          new DelegateCommand(selectFolder);
      }
    }

    private void selectFolder()
    {
      TestText = "select Folder!!";

      SelectFolderRequest.Raise(new Confirmation { Title = "", Content = new FileMessage() },
        (confirmation) =>
        {
          if (confirmation.Confirmed)
          {
            var fileMessage = confirmation.Content as FileMessage;
            TestText = fileMessage.FileName;
          }
        }
        );
    }

    private InteractionRequest<Confirmation> _OpenFileRequest;
    public InteractionRequest<Confirmation> OpenFileRequest
    {
      get
      {
        return this._OpenFileRequest = this._OpenFileRequest ??
          new InteractionRequest<Confirmation>();
      }
    }

    private InteractionRequest<Confirmation> _SaveFileRequest;
    public InteractionRequest<Confirmation> SaveFileRequest
    {
      get
      {
        return this._SaveFileRequest = this._SaveFileRequest ??
          new InteractionRequest<Confirmation>();
      }
    }

    private InteractionRequest<Confirmation> _SelectFolderRequest;
    public InteractionRequest<Confirmation> SelectFolderRequest
    {
      get
      {
        return this._SelectFolderRequest = this._SelectFolderRequest ??
          new InteractionRequest<Confirmation>();
      }
    }
  }
}
