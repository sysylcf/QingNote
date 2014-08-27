using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  public interface FileReadingOverseer
  {
    KeyValuePair<Instruction, string> onMultipleFileExist(List<string> files);
    Instruction onFileNotExist();
    Instruction onFileLangInvalid();
    Instruction onFileInvalid(string reason, params string[] args);
  }
}
