export default class AddItemValidator{
  itemName = {
    check: value => {
      return value.length > 2
    },

    hint: value => {
      return "Length must be greater than 2";
    }
  }

  description = {
    check: value => {
      return value.length > 10
    },

    hint: value => {
      return "Length must be greater than 10";
    }
  }
}
