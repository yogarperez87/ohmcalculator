let getContrast = function (hexcolor) {
	try {
		if (!hexcolor)
			return false;
		// If a leading # is provided, remove it
		if (hexcolor.slice(0, 1) === '#') {
			hexcolor = hexcolor.slice(1);
		}

		// If a three-character hexcode, make six-character
		if (hexcolor.length === 3) {
			hexcolor = hexcolor.split('').map(function (hex) {
				return hex + hex;
			}).join('');
		}

		// Convert to RGB value
		var r = parseInt(hexcolor.substr(0, 2), 16);
		var g = parseInt(hexcolor.substr(2, 2), 16);
		var b = parseInt(hexcolor.substr(4, 2), 16);

		// Get YIQ ratio
		var yiq = ((r * 299) + (g * 587) + (b * 114)) / 1000;

		// Check contrast
		return (yiq >= 190) ? 'black' : 'white';
	} catch (error) {
		console.error(error);
		return 'black';
	}

};



let roundK = (numb, decPlaces = 6) => {
	let number = numb;
	try {
		decPlaces = Math.pow(10, decPlaces);
		var abbrev = ["K", "M", "B", "T"];
		for (var i = abbrev.length - 1; i >= 0; i--) {

			var size = Math.pow(10, (i + 1) * 3);
			if (size <= number) {
				number = Math.round(number * decPlaces / size) / decPlaces;
				if ((number == 1000) && (i < abbrev.length - 1)) {
					number = 1;
					i++;
				}

				number += abbrev[i];

				break;
			}
		}

		return number;
	} catch (error) {
		console.error(error)
		return numb;
	}

}

export default {
	getContrast,
	roundK
}
