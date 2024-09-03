using Microsoft.AspNetCore.Mvc;

public class zTodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomSuccessResponse<TaskEntity>> Create(CreateTodoDto dto)
    {
        TaskEntity newTask = new TaskEntity { Text = dto.Text };
        await _repository.Create(newTask);
        return new CustomSuccessResponse<TaskEntity>
        {
            Data = newTask,
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }

    public async Task<BaseSuccessResponse> PatchStatusAll(PatchTodoDro status)
    {
        await _repository.PatchStatusAll(status.Status);
        return new BaseSuccessResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }

    public async Task<BaseSuccessResponse> Delete()
    {
        await _repository.Delete();
        return new BaseSuccessResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }

    public async Task<BaseSuccessResponse> DeleteId(long id)
    {
        if (await _repository.GetEntity(id) == null)
        {
            return new BaseSuccessResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Success = false
            };
        }
        await _repository.DeleteId(id);
        return new BaseSuccessResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }

    public async Task<BaseSuccessResponse> PatchStatus(long id, PatchTodoDro status)
    {
        await _repository.PatchStatus(id, status.Status);
        if (await _repository.GetEntity(id) == null)
        {
            return new BaseSuccessResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Success = false
            };
        }
        return new BaseSuccessResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }

    public async Task<BaseSuccessResponse> PatchText(long id, ChangeTextTodoDto dto)
    {
        await _repository.PatchText(id, dto.Text);
        if (await _repository.GetEntity(id) == null)
        {
            return new BaseSuccessResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Success = false
            };
        }
        return new BaseSuccessResponse
        {
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
    }
    
    public async Task<CustomSuccessResponse<TaskListResponse>> GetTasks(int page, int perPage, bool? status)
    {
        var pageEntity = await _repository.GetPaginated(page, perPage, status);
        var totalCount = await _repository.GetCount(null);
        var completedCount = await _repository.GetCount(true);
        var incompleteCount = await _repository.GetCount(false);

        var response = new TaskListResponse
        {
            Data = pageEntity,
            TotalCount = totalCount,
            CompletedCount = completedCount,
            IncompleteCount = incompleteCount,
            StatusCode = StatusCodes.Status200OK,
            Success = true
        };
        return new CustomSuccessResponse<TaskListResponse>(response);
    }

}
