import React from "react";

import "./styles.css";

interface CheckBoxCustomProps {
  isChecked: boolean;
  label: string;
  onChange?: (e: Event) => void;
}

const CheckBoxCustom: React.FC<CheckBoxCustomProps> = ({
  isChecked,
  label,
  onChange,
}) => {
  return (
    <label className="labelContainer">
      <span className="check"></span>
      <input type="checkbox" />
      {label}
    </label>
  );
};

export default CheckBoxCustom;
