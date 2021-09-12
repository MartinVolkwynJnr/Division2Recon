import * as types from "./actionTypes";

export function loadProcessesSuccess(processes) {
  return { type: types.LOAD_PROCESSES_SUCCESS, processes };
}

