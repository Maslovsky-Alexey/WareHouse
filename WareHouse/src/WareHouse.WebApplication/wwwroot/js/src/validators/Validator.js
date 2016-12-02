import AddItemValidator from './AddItemValidator';
import OperationValidator from './OperationValidator';

export default function GetValidationRules(){
   const validators = [AddItemValidator, OperationValidator];

   let rules = {};

   for (var i = 0; i < validators.length; i++){
     Object.assign(rules, new validators[i]());

   }

   return rules;
}
