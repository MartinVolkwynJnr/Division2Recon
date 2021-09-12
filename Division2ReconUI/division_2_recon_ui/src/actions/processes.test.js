import * as processActions from "./processesActions";
import * as types from "./actionTypes";

describe("getProcessesSuccess", () => {
    it("should get a LOAD_PROCESSES_SUCCESS action",() => {
        //arrange
        const expectedAction = {
            type: types.LOAD_PROCESSES_SUCCESS
        };

        //act
        const action = processActions.loadProcessesSuccess()

        expect(action).toEqual(expectedAction);
    })
})