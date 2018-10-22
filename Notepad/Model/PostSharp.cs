using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Windows;

namespace Notepad.PostSharp
{
    [PSerializable]
    public class PostSharpExceptionAttribute : OnExceptionAspect
    {

        public override void OnException(MethodExecutionArgs args)
        {
            MessageBox.Show(args.Exception.Message);
        }
    }
}
