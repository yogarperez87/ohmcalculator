import React from 'react'
import './Result.css'

function Result({ total, tolerancy }) {
    return (
        <div className="resistor">
            <span> Result: {total || "###"} Ohms {tolerancy? "+/-"+tolerancy+"%":null }</span>
        </div>
    )
}

export default Result
