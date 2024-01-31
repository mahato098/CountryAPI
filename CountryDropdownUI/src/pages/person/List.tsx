import { useQuery } from "@tanstack/react-query"
import BASE_URL from '../../constant/BASE_URL'
import axios from 'axios'
import moment from 'moment';

interface IPerson {
    personId: number,
    firstName: string,
    lastName: string,
    joinDate: Date,
    countryName: string,
    stateName: string,
    districtName: string,
    cityName: string
}

const List = () => {

    const fetchPersons = async() => {
        try{
            const response = await axios.get<IPerson[]>(`${BASE_URL}/Person/GetAllPersons`);
            return response;
        }
        catch(error){
            throw new Error(`Error Fetching Person List: ${error}`)
        }
    }

    const {data, error, isLoading, isError} = useQuery<IPerson[], Error>({
        queryKey: ["persons"],
        queryFn: fetchPersons
    })

    if(isError) return <div>Error Occurred: ${error.message}</div>

    if(isLoading) return <div>Loading...</div>

    console.log("persons :", data)

  return (
    <div className="mt-[30px]">
        <table className="min-w-full text-left text-sm font-light ml-6 mt-5">
        <thead className="border-b font-medium dark:border-neutral-500">
            <tr>
                <th>No.</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Join Date</th>
                <th>Country Name</th>
                <th>State Name</th>
                <th>District Name</th>
                <th>City Name</th>
            </tr>
        </thead>

        <tbody>
            {
            data?.data.map((person, index) => (
                <tr key={person.personId} className="text-gray-900">
                    <td>{index + 1}</td>
                    <td>{person.firstName}</td>
                    <td>{person.lastName}</td>
                    <td>{moment(person.joinDate).format('YYYY-MM-DD')}</td>
                    <td>{person.countryName}</td>
                    <td>{person.stateName}</td>
                    <td>{person.districtName}</td>
                    <td>{person.cityName}</td>
                </tr>
            ))
            }
        </tbody>

        </table>
   </div>
  )
}

export default List
