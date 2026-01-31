using System;
using Fluxor;

namespace FluxorDispatchIssue.Store;

public static class Reducers
{
    [ReducerMethod(typeof(IncrementCounterAction))]
    public static CounterState Reduce(CounterState state) => new CounterState(state.ClickCount + 1);
}
