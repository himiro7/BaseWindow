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
  public class OpenFileAction : TargetedTriggerAction<DependencyObject>
  {
    /// <summary>
    /// MainWindowのOpenFileメニューがクリックされた時にファイルオープンダイアログを開く
    /// </summary>
    /// <param name="parameter">InteractionRequestedEventArgsらしいです。</param>
    protected override void Invoke(object parameter)
    {
      var args = parameter as InteractionRequestedEventArgs;
      var ctx = args.Context as Confirmation;
      ctx.Confirmed = false;

      var openFileDailog = new OpenFileDialog();
      if(openFileDailog.ShowDialog().GetValueOrDefault())
      {
        var fileMessage = ctx.Content as FileMessage;
        fileMessage.FileName = openFileDailog.FileName;

        ctx.Confirmed = true;
      }

      args.Callback();
    }
  }
}
