export default function generateSupplyModel(onSucces, onFailure){
  return [
      {
          type: 'text',
          caption: 'Count',
          get: (item) => item.count
      },
      {
          type: 'text',
          caption: 'When',
          get: (item) => item.dateTime
      },
      {
          type: 'text',
          caption: "Provider",
          get: (item) => item.provider.name
      },
      {
          type: 'text',
          caption: "Employee",
          get: (item) => item.employee.name
      },
      {
          type: 'text',
          caption: "Item",
          get: (item) => item.item.name
      },
      {
          type: 'text',
          caption: "Status",
          get: (item) => item.status.name
      },
      {
          type: 'button',
          caption: 'Success',
          onClick: (item) => onSucces(item)
      },
      {
          type: 'button',
          caption: 'Failure',
          onClick: (item) => onFailure(item)
      }
  ];
}
