
/// <summary>
/// Enums of states for the panicked person AI.
/// </summary>
public enum PanickedState
{
    /// <summary>
    /// When the agent is healthy.
    /// </summary>
   Running,

   /// <summary>
   /// When the agent is wounded.
   /// </summary>
   RunningSlower,

   /// <summary>
   /// When the agent is severly wounded.
   /// </summary>
   WoundedInTheGround,

   /// <summary>
   /// When the agent is dead.
   /// </summary>
   Dead,
}
