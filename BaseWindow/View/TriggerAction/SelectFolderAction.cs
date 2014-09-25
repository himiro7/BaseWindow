using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Interactivity;
using BaseWindow.Message;
using System.Windows.Forms;

using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace BaseWindow.View.TriggerAction
{
  public class SelectFolderAction : TargetedTriggerAction<DependencyObject>
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

      var folderDailog = new FolderBrowserDialog();
      if (folderDailog.ShowDialog() == DialogResult.OK)
      {
        var fileMessage = ctx.Content as FileMessage;
        fileMessage.FileName = folderDailog.SelectedPath;

        ctx.Confirmed = true;
      }

      args.Callback();
    }
  }
}
