import React, { Component } from 'react';
import { Button } from '@material-ui/core';
import { IconButton } from '@material-ui/core';
import LeftIcon from '@material-ui/core/internal/svg-icons/KeyboardArrowLeft';
import RightIcon from '@material-ui/core/internal/svg-icons/KeyboardArrowRight';
import ReportIcon from '@material-ui/core/internal/svg-icons/CheckCircle';
import Tooltip from '@material-ui/core/Tooltip';
import { makeStyles } from '@material-ui/core/styles';


export class PlaceRobot extends Component {
    static displayName = PlaceRobot.name;

    constructor(props) {
        super(props);
        this.state = { currentX: 0, currentY: 0, robDirection: "North" };
        this.placeRobot = this.placeRobot.bind(this);
        this.moveRobot = this.moveRobot.bind(this);
        this.leftRobot = this.leftRobot.bind(this);
        this.rightRobot = this.rightRobot.bind(this);
        this.reportRobot = this.reportRobot.bind(this);
        this.handleXChange = this.handleXChange.bind(this);
        this.handleYChange = this.handleYChange.bind(this);
        this.handleDirectionChange = this.handleDirectionChange.bind(this);
        this.handleValidation = this.handleValidation.bind(this);

    }

    placeRobot() {
        if (this.handleValidation()) {
            alert("Placed robot at : " + this.state.currentX + " : " + this.state.currentY + " : " + this.state.robDirection);
        } else {
            alert("Coordinate Invalid");
        }
    }

    moveRobot() {
        if (this.state.currentY <= 5 && this.state.currentX <= 5) {
            switch (this.state.robDirection.toLowerCase()) {
                case 'north':
                    if (this.state.currentY != 5)
                        this.setState({ currentY: ++this.state.currentY })
                    break;
                case 'south':
                    if (this.state.currentY != 0)
                        this.setState({ currentY: --this.state.currentY })
                    break;
                case 'east':
                    if (this.state.currentX != 5)
                        this.setState({ currentX: ++this.state.currentX })
                    break;
                case 'west':
                    if (this.state.currentX != 0)
                        this.setState({ currentX: --this.state.currentX })
                    break;
            }
        }
        if (!this.handleValidation()) {
            alert("Coordinate Invalid");
        }
    }

    leftRobot() {
        switch (this.state.robDirection.toLowerCase()) {
            case 'north':
                this.setState({ robDirection: "WEST" })
                break;
            case 'south':
                this.setState({ robDirection: "EAST" })
                break;
            case 'east':
                this.setState({ robDirection: "NORTH" })
                break;
            case 'west':
                this.setState({ robDirection: "SOUTH" })
                break;
        }

    }

    rightRobot() {
        switch (this.state.robDirection.toLowerCase()) {
            case 'north':
                this.setState({ robDirection: "EAST" })
                break;
            case 'south':
                this.setState({ robDirection: "WEST" })
                break;
            case 'east':
                this.setState({ robDirection: "SOUTH" })
                break;
            case 'west':
                this.setState({ robDirection: "NORTH" })
                break;
        }

    }

    reportRobot() {
        alert("Roporting Robot position at : " + this.state.currentX + " : " + this.state.currentY + " : " + this.state.robDirection);
    }

    handleValidation() {
        if (this.state.currentX >= 0 && this.state.currentX <= 5 && this.state.currentY >= 0 && this.state.currentY <= 5)
            return true;
        this.state.currentX = 0;
        this.state.currentY = 0;
        return false;
    }

    handleXChange(event) {
        this.setState({
            currentX: event.target.value
        })
    }

    handleYChange(event) {
        this.setState({
            currentY: event.target.value
        })
    }

    handleDirectionChange(event) {
        this.setState({
            robDirection: event.target.value
        })
    }

    render() {
        return (
            <div>
                <h1>Robot Vacuum</h1>
                <label>X
                <input type="text" value={this.state.currentX} onChange={this.handleXChange} /></label>
                <label>Y
                <input type="text" value={this.state.currentY} onChange={this.handleYChange} /></label>
                <label>
                    Direction:
          <select value={this.state.robDirection} onChange={this.handleDirectionChange}>
                        <option value="North">NORTH</option>
                        <option value="South">SOUTH</option>
                        <option value="East">EAST</option>
                        <option value="West">WEST</option>
                    </select>
                </label>
                <p aria-live="polite">Current Position: <strong>{this.state.currentX} : {this.state.currentY} : {this.state.robDirection}</strong></p>

                <Button variant="contained" color="Primary" onClick={this.placeRobot}>PLACE</Button>

                <p> Click on Place to fix robot position </p>

                <Button variant="contained" color="Secondary" onClick={this.moveRobot}>MOVE</Button>

                <p> Click on Move to move robot. </p>

                <view style={{ flexDirection: "row" }}>
                    <IconButton color="Primary" Tooltip="LEFT" onClick={this.leftRobot}>
                        <LeftIcon />
                    </IconButton >
                    <IconButton color="Primary" Tooltip="RIGHT" onClick={this.rightRobot}>
                        <RightIcon />
                    </IconButton>
                </view>
                <p> Click arrows to turn Robot Left/Right. </p>

                <Button variant="contained" color="secondary"
                    startIcon={<ReportIcon />} onClick={this.reportRobot}>REPORT</Button>

                <p> Click on Report to display Robot position. </p>
            </div>
        );
    }
}
