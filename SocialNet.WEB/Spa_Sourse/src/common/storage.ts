export class BrowserStorage
{
  public setObject<T>(key: string, object: T): void
  {
    const data = JSON.stringify(object);
    localStorage.setItem(key, data);
  }

  public getObject<T>(key: string): T
  {
    let result: T;

    const data = localStorage.getItem(key);

    try
    {
      result = JSON.parse(data);
    }
    catch (e)
    {
      console.error(e);
    }

    return result;
  }

  public removeItem<T>(key: string): void
  {
    localStorage.removeItem(key);
  }
}
