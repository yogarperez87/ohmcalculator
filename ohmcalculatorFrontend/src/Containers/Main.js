import React from 'react';
import './Main.css';
import Parameters from './Parameters.js';
import Result from '../Components/Result.js';
import Title from '../Components/Title.js';

function Main({ total, bandValues, ...restProps }) {
  return (
    <main className="Main">
      <div className="row">
        <div className="col">
          <Title text="Ohm Value Calculator" />
        </div>
      </div>
      <div className="row content">
        <div className="col">
          <Parameters {...restProps} />
        </div>
      </div>
      <div className="row content">
        <div className="col">
          <Result total={total} tolerancy={bandValues.bandDColor} />
        </div>
        <div className="col">

        </div>
      </div>
    </main>
  );
}

export default Main;
