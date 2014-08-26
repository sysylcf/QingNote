namespace cn.zuoanqh.open.QingNote
{
  /// <summary>
  /// Continue: Do the default behaviour
  /// Abort_Return_Null: exactly as it says
  /// Abort_Return_Current: if there's some process, return the process, null or empty otherwise
  /// Skip: Skip the problem.
  /// Restart: Start over with same parameters.
  /// Choose: Choose the one specified by overseer.
  /// </summary>
  public enum Instruction { CONTINUE, ABORT_RETURN_NULL, ABORT_RETURN_CURRENT, SKIP, RESTART, CHOOSE }
}