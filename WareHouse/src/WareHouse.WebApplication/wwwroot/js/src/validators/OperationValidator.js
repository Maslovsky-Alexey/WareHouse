export default class OperationValidator{
  validateCount = {
    check: value => {
      return isNaN(value) == false && value > 0;
    },


    hint: value => {
      return "Value must be a number and greater than 0";
    }
  }
}
