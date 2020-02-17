
import React, { useState } from 'react'
import PropTypes from 'prop-types';
import './Dropdown.css'
import DropdownItem from './DropdownItem'
import common from '../../Functions/Common'

export default function Dropdown({ items = [], name, setBandColor, setBandValue, prefix, label, ...restProps }) {

  //let initialItems = [{ Name: "White", Code: "#fff" }, { Name: "Brown", Code: "#512627" }]
  //const [items, setItems] = useState(initialItems);
  const [selectedItem, setSelectedItem] = useState({ Name: "Select a Color", Code: "#fff" });

  function handleClick(e, Name, Code, Value) {
    e.preventDefault();
    setSelectedItem({ Name, Code, Value })
    setBandColor(name, Name)
    setBandValue && setBandValue(name, Value)
  }

  return (
    <>
      <label>{label}</label>
      <div className="btn-group dropdown">
        <DropdownItem
          toggle
          name={selectedItem.Name}
          code={selectedItem.Code}
          value={selectedItem.Value}
          displayValue={common.roundK}
          className="btn dropdown-toggle"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
          prefix={prefix}
        />
        <div className="dropdown-menu">
          {
            items.map(item => <DropdownItem
              key={item.Name}
              name={item.Name}
              code={item.Code}
              value={item.Value}
              onClick={(e) => handleClick(e, item.Name, item.Code, item.Value)}
              className="dropdown-item"
              displayValue={common.roundK}
              prefix={prefix}
            />)
          }
        </div>
      </div>
    </>
  )
}

Dropdown.propTypes = {
  setBandColor: PropTypes.func.isRequired,
  setBandValue: PropTypes.func
}

function DropdownButton({ Name, Code, className = "", ...restProps }) {
  let classNames = ["btn", "btn-primary", className].join(" ");
  return (
    <button type="button" className={classNames} {...restProps} >
      {Name}
    </button>
  )
}





