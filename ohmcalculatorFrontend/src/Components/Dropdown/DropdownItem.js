
import React, { useState } from 'react'
import './DropdownItem.css'
import common from '../../Functions/Common'

export default function DropdownItem({ name, code, value, handleClick, className = "", toggle, displayValue, ...restProps }) {
  let classNames = [className].join(" ");
  let style = {
    backgroundColor: code,
    color: common.getContrast(code)
  }
  if ((toggle && !code) || (toggle && code && (code.toLowerCase() === "#fff" || code.toLowerCase() === "#ffffff"))) {
    style.borderColor = "#ccc";
  }
  //onClick={(e) => handleClick(e, name, code)}
  return (
    <button
      className={classNames}
      style={style}
      type="button"
      {...restProps}
    >
      <DropdownItemContent value={value} name={name} toggle={toggle} displayValue={displayValue} {...restProps}  />
    </button>
  )
}

function DropdownItemContent({value, name, toggle, displayValue, prefix, ...restProps}){
  return (
    <div className="row justify-content-between">
        {value ?
          <div className="col">
            {prefix || ""} {displayValue(value) || ""}
          </div> : null
        }
        <div className="col text-right">
          <span>{name} { toggle?<span className="down"></span>: null}</span>
        </div>
      </div>
  );
}






