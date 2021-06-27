import React, { Component } from 'react';

export class MoveRobot extends Component {
    static displayName = MoveRobot.name;

    constructor(props) {
        super(props);
        this.state = { currentX: 0, currentY: 0, robDirection: "North" };


    }

    renderSwitch(param) {
        switch (param) {
            case 'foo':
                return 'bar';
            default:
                return 'foo';
        }
    }

    render() {

        return (
            <div>
                <h1>Move Robot Position</h1>
                <p>Robot Position is at {this.props.x}    ,{this.props.y}   , {this.props.direction}  </p>
            </div>
        );
    }
}
