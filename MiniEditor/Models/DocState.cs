using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEditor.Models
{
    internal class DocState
    {
        public string Text { get; }

        public DocState(string text)
        {
            Text = text ?? string.Empty;
        }

        public override string ToString() => $"DocState(len={Text?.Length ?? 0})";
    }
}
