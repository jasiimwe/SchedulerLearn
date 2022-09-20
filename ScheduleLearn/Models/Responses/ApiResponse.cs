namespace ScheduleLearnApi.Models.Responses
{
    public class ApiResponse<TEntity>
    {
        public TEntity Data { get; set; }
        public string Message { get; set; }
        public bool check { get; set; }


        public ApiResponse(TEntity entity, string message)
        {
            check = true;
            Message = message;
            Data = entity;
        }

        public ApiResponse(string message)
        {
            check = false;
            Message = message;
            Data = default;

        }

    }
}
