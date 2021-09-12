import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function processesReducer(state = initialState.processes, action) {
  switch (action.type) {
    // case types.CREATE_CONTACT_SUCCESS:
    //   return [...state, { ...action.contact }];
    // case types.UPDATE_CONTACT_SUCCESS:
    //   return state.map(contact =>
    //     contact.id === action.contact.id ? action.contact : contact
    //   );
    case types.LOAD_PROCESSES_SUCCESS:
      return action.processes;
    // case types.DELETE_CONTACT_OPTIMISTIC:
    //   return state.filter(contact => contact.id !== action.contact.id);
    default:
      return state;
  }
}
