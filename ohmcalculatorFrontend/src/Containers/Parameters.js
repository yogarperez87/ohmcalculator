import React from 'react'
import './Main.css';
import Dropdown from '../Components/Dropdown/Dropdown'

function Parameters({pbands, mbands, tbands, setBandValue, ...restProps}) {
  
  return (
    <div className="row">
      <div className="col-sm">
        <Dropdown label="1st Band of Color" items={pbands} name="bandAColor" {...restProps} />
      </div>
      <div className="col-sm">
        <Dropdown label="2nd Band of Color" items={pbands} name="bandBColor" {...restProps} />
      </div>
      <div className="col-sm">
        <Dropdown label="Multiplier" items={mbands} name="bandCColor" prefix="x" {...restProps} />
      </div>
      <div className="col-sm">
        <Dropdown label="Tolerance" items={tbands} name="bandDColor" prefix="+/-" {...restProps} setBandValue={setBandValue} />
      </div>
    </div>
  );
}

export default Parameters;
