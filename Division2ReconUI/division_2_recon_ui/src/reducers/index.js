import { combineReducers } from "redux";
import { connectRouter } from "connected-react-router";
import processesReducer from "../reducers/processesReducer";
import apiCallsInProgress from "../reducers/apiStatusReducer";

const rootReducer = history =>
  combineReducers({
    router: connectRouter(history),
    processes: processesReducer,
    apiCallsInProgress
  });

export default rootReducer;
