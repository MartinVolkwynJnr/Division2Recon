import { handleResponse, handleError } from "./apiUtils";
const baseUrl = "/api/processes";

export function getProcesses() {
  return fetch(baseUrl)
    .then(handleResponse)
    .catch(handleError);
}

export function getProcess(process) {
  return fetch(baseUrl + "/GetProcess/" + process)
    .then(handleResponse)
    .catch(handleError);
}

export function SearchBySensorData(searchString) {
  return fetch(baseUrl + "/SearchBySensorData/" + searchString)
    .then(handleResponse)
    .catch(handleError);
}

export function SearchByCustomerName(searchString) {
  return fetch(baseUrl + "/SearchByCustomerName/" + searchString)
    .then(handleResponse)
    .catch(handleError);
}

