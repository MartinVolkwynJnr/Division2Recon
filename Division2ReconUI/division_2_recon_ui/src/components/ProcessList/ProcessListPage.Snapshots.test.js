import React from "react";
import ProcessListPage from "./ProcessListPage";
import renderer from "react-test-renderer";
import {render} from "@testing-library/react";

it("check general display of snapshot change/update", () => {
    const tree = renderer.create(
        <ProcessListPage />
    );
    expect(tree).toMatchSnapshot();
})

it("should render a button with text 'Search CustomerName'", () => {
    const {getByText} = render(<ProcessListPage />);
    getByText("Search CustomerName");
})

it("should render a button with text 'Search SensorData'", () => {
    const {getByText} = render(<ProcessListPage />);
    getByText("Search SensorData");
})