import Button from "../../components/common/Button"
import { useQuery } from "@tanstack/react-query"
import BASE_URL from '../../constant/BASE_URL'
import axios from 'axios'


interface ICountry {
  countryId: number,
  countryName: string
}

const List = () => {

  const fetchCountry = async() => {
    try{
      const response = await axios.get<ICountry[]>(`${BASE_URL}/Country/GetAllCountry`);
      //console.log(response.data);
      return response.data
    }
    catch(error){
      throw new Error(`Error Fetching Country List: ${error}`);
    }
  }

  const {data, error, isLoading, isError} = useQuery<ICountry[], Error>({
    queryKey: ["countries"],
    queryFn: fetchCountry
  })

  if(isError) return <div>Error Occurred: {error.message}</div>

  if(isLoading) return <div>Loading...</div>

  console.log("countries: ", data)


    const handleButtonClick = (event: React.MouseEvent<HTMLButtonElement>) =>{
      console.log('button click',event)
    }

  return (
    <div>
      <div className="bg-teal-500 hover:bg-teal-700 text-white w-[90px] h-[35px] rounded-md flex justify-center items-center float-end">
        <Button handleClick={handleButtonClick} value="Add New" />
      </div>
     <div className="mt-[30px]">
      <table className="min-w-full text-left text-sm font-light ml-6 mt-5">
        <thead className="border-b font-medium dark:border-neutral-500">
          <tr>
            <th>No.</th>
            <th>Country Name</th>
          </tr>
        </thead>

        <tbody>
          {
            data?.map((country, index) => (
              <tr key={country.countryId} className="text-gray-900">
                <td>{index + 1}</td>
                <td>{country.countryName}</td>
              </tr>
            ))
          }
        </tbody>

      </table>
     </div>
    </div>
  )
}

export default List
