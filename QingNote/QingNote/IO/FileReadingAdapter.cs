using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.QingNote.IO
{
  /// <summary>
  /// Basically a bunch of default behaviour so you dont have to implement unless you need to change it.
  /// </summary>
  public class FileReadingAdapter : FileReadingOverseer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
    /// <returns></returns>
    public KeyValuePair<Instruction, string> onMultipleFileExist(List<string> files)
    {
      return new KeyValuePair<Instruction, string>(Instruction.CONTINUE, "");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Instruction.ABORT_RETURN_NULL</returns>
    public Instruction onFileNotExist()
    {
      return Instruction.ABORT_RETURN_NULL;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Instruction.CONTINUE</returns>
    public Instruction onFileLangInvalid()
    {
      return Instruction.CONTINUE;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="args"></param>
    /// <returns>Instruction.CONTINUE</returns>
    public Instruction onFileInvalid(string reason, params string[] args)
    {
      return Instruction.CONTINUE;
    }
  }
}
