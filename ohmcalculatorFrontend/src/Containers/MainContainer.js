import React, { useState, useEffect, useRef } from 'react'
import Main from './Main'
import $ from 'jquery';



export default function MainContainer() {
  let initialItems = []
  const [pbands, setPbands] = useState(initialItems);
  const [mbands, setMbands] = useState(initialItems);
  const [tbands, setTbands] = useState(initialItems);
  const [total, setTotal] = useState("");
  const [bandValues, setBandValues] = useState({});

  const bandColors = useRef({});
  ///const bandValues = useRef({});

  function setBandColor(name, value) {
    try {
      if (name && value) {
        bandColors.current[name] = value;
        if (checkForAllBands(bandColors.current, ["bandAColor", "bandBColor", "bandCColor", "bandDColor"])) {
          calculate();
        }
      }
    } catch (error) {
      console.error(error);
    }
  }

  function setBandValue(name, value) {
    try {
      if (name && value) {
        let tempBandValues = bandValues;
        tempBandValues[name] = value;
        setBandValues(tempBandValues);
      }
    } catch (error) {
      console.error(error);
    }
  }

  function calculate() {
    getCalculation("calcohmvalue", bandColors.current, (response) => {
      setTotal(response);
    })
  }

  useEffect(() => {

    getBands("getpbands", (response) => {
      setPbands(response.Bands)
    });
    getBands("getmbands", (response) => {
      setMbands(response.Bands)
    });
    getBands("gettolbands", (response) => {
      setTbands(response.Bands)
    });
  }, []);

  return (
    <Main pbands={pbands}
      mbands={mbands}
      tbands={tbands}
      setBandColor={setBandColor}
      total={total}
      setBandValue={setBandValue}
      bandValues = {bandValues}
    />
  )
}

function checkForAllBands(values, requireds) {
  try {
    for (const iterator of requireds) {
      if (!values[iterator])
        return false;
    }
    return true;
  } catch (error) {
    console.error(error)
  }

}

function getBands(path, cb) {
  $.ajax({
    url: `http://127.0.0.1:3003/oc/${path}`,
    data: "",
    type: "GET",
    dataType: "json",
    // contentType:"text/plain",  
    // headers: {
    //   'Access-Control-Allow-Origin': "*"
    // },  
    success: function (data) {
      cb(data);
    },
    error: function (jqXHR, textStatus, errorThrown) {
      console.error(errorThrown);
    }
  });
}

function getCalculation(path, data, cb) {
  $.ajax({
    url: `http://127.0.0.1:3003/oc/${path}`,
    data: "",
    type: "GET",
    dataType: "json",
    // contentType:"text/plain",  
    // headers: {
    //   'Access-Control-Allow-Origin': "*"
    // },  
    data: {
      bandAColor: data.bandAColor,
      bandBColor: data.bandBColor,
      bandCColor: data.bandCColor,
      bandDColor: data.bandDColor
    },
    success: function (data) {
      if (data.Rc === '200')
        cb(data.Value);
      else
        console.error(data);
    },
    error: function (jqXHR, textStatus, errorThrown) {
      console.error(errorThrown);
    }
  });
}


