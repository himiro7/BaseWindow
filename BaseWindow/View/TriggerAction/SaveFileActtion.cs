using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Windows;
using System.Windows.Interactivity;
using BaseWindow.Message;
using Microsoft.Win32;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace BaseWindow.View.TriggerAction
{
  public class SaveFileAction : TargetedTriggerAction<DependencyObject>
  {
    /// <summary>
    /// MainWindowのsaveFileメニューがクリックされた時にセーブオープンダイアログを開く
    /// </summary>
    /// <param name="parameter">InteractionRequestedEventArgsらしいです。</param>
    protected override void Invoke(object parameter)
    {
      var args = parameter as InteractionRequestedEventArgs;
      var ctx = args.Context as Confirmation;
      ctx.Confirmed = false;

      var saveFileDailog = new SaveFileDialog();
      if (saveFileDailog.ShowDialog().GetValueOrDefault())
      {
        var fileMessage = ctx.Content as FileMessage;
        fileMessage.FileName = saveFileDailog.FileName;

        ctx.Confirmed = true;
      }

      args.Callback();
    }
  }
}
