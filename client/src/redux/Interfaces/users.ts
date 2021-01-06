export interface IUsers {
  id: number;
  username: string;
  cuisines: [];
  productCarts: [];
  role: {
    id: string;
    name: string;
  };
}
